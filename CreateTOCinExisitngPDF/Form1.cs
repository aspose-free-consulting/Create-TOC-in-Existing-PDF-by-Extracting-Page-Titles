using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace CreateTOCinExisitngPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "License Files (*.lic)|*.lic|All files (*.*)|*.*";
            fd.InitialDirectory = @"C:\";
            fd.Title = "Please select a License file to Use.";
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtLicense.Text = fd.FileName;
                License lic = new License();
                lic.SetLicense(txtLicense.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            fd.InitialDirectory = @"C:\";
            fd.Title = "Please select a PDF file to upload.";
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtPDF.Text = fd.FileName;
                lstTitles.Items.Clear();
            }
        }

        private void btnExtractTitles_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtLicense.Text) && !String.IsNullOrEmpty(txtPDF.Text))
                {
                    Document doc = new Document(txtPDF.Text);
                    foreach (Page page in doc.Pages)
                    {
                        TextFragmentAbsorber absorber = new TextFragmentAbsorber();
                        page.Accept(absorber);
                        if (lstTitles.Items.Contains(absorber.TextFragments[1].Text))
                        { continue; }
                        lstTitles.Items.Add(absorber.TextFragments[1].Text);
                        page.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Please select License and PDF file first.", "No File Selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCreateTOC_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTitles.Items.Count > 0)
                {
                    Document doc = new Document(txtPDF.Text);
                    Page tocPage = doc.Pages.Insert(1);

                    // Create object to represent TOC information
                    TocInfo tocInfo = new TocInfo();
                    TextFragment title = new TextFragment("Table Of Contents");
                    title.TextState.FontSize = 20;
                    title.TextState.FontStyle = FontStyles.Bold;

                    // Set the title for TOC
                    tocInfo.Title = title;
                    tocPage.TocInfo = tocInfo;
                    foreach (var item in lstTitles.Items)
                    {
                        TextFragmentAbsorber absorber = new TextFragmentAbsorber(item.ToString());
                        doc.Pages.Accept(absorber);
                        Page targetPage = doc.Pages[absorber.TextFragments[1].Page.Number];
                        // Create Heading object
                        Aspose.Pdf.Heading heading2 = new Aspose.Pdf.Heading(1);
                        TextSegment segment2 = new TextSegment();
                        heading2.TocPage = tocPage;
                        heading2.Segments.Add(segment2);
                        // Specify the destination page for heading object
                        heading2.DestinationPage = targetPage;
                        // Destination page
                        heading2.Top = targetPage.Rect.Height;
                        // Destination coordinate
                        segment2.Text = item.ToString();
                        // Add heading to page containing TOC
                        tocPage.Paragraphs.Add(heading2);
                    }
                    doc.Save("Toc_out.pdf");
                    MessageBox.Show("PDF with TOC has been created.", "Success");
                }
                else
                {
                    MessageBox.Show("Please extract titles from PDF document first.", "Titles are not extracted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTitles.Items.Count > 0)
                {
                    Dictionary<string, List<int>> titles = new Dictionary<string, List<int>>();
                    List<string> ts = new List<string>();
                    Document doc = new Document(txtPDF.Text);
                    foreach (Page page in doc.Pages)
                    {
                        TextFragmentAbsorber absorber = new TextFragmentAbsorber();
                        page.Accept(absorber);
                        if (titles.Where(x => x.Key == absorber.TextFragments[1].Text).ToList().Count > 0)
                        {
                            titles[absorber.TextFragments[1].Text].Add(absorber.TextFragments[1].Page.Number);
                            ts.Remove(absorber.TextFragments[1].Text);
                        }
                        else
                        {
                            titles.Add(absorber.TextFragments[1].Text, new List<int>() { absorber.TextFragments[1].Page.Number });
                            ts.Add(absorber.TextFragments[1].Text);
                        }
                    }
                    // Get chapters which are more than 1 page
                    var pages = titles.Where(x => x.Value.Count > 1).Select(x => x.Value).ToList();
                    List<int> ps = new List<int>();
                    if (pages.Count > 0)
                    {
                        foreach (var page in pages)
                        {
                            Document newDoc = new Document();
                            foreach (var p in page)
                            {
                                newDoc.Pages.Add(doc.Pages[p]);
                                ps.Add(p);
                            }
                            newDoc.Save("newPDF_" + DateTime.Now.Millisecond + ".pdf");
                        }
                        // Delete extracted pages from existing PDF
                        doc.Pages.Delete(ps.ToArray());
                        doc.Save("tmp.pdf");
                    }
                    // Create TOC for remaining pages
                    doc = new Document("tmp.pdf");
                    Page tocPage = doc.Pages.Insert(1);

                    // Create object to represent TOC information
                    TocInfo tocInfo = new TocInfo();
                    TextFragment title = new TextFragment("Table Of Contents");
                    title.TextState.FontSize = 20;
                    title.TextState.FontStyle = FontStyles.Bold;

                    // Set the title for TOC
                    tocInfo.Title = title;
                    tocPage.TocInfo = tocInfo;
                    foreach (var s in ts)
                    {
                        TextFragmentAbsorber absorber = new TextFragmentAbsorber(s);
                        doc.Pages.Accept(absorber);
                        Page targetPage = doc.Pages[absorber.TextFragments[1].Page.Number];
                        // Create Heading object
                        Aspose.Pdf.Heading heading2 = new Aspose.Pdf.Heading(1);
                        TextSegment segment2 = new TextSegment();
                        heading2.TocPage = tocPage;
                        heading2.Segments.Add(segment2);
                        // Specify the destination page for heading object
                        heading2.DestinationPage = targetPage;
                        // Destination page
                        heading2.Top = targetPage.Rect.Height;
                        // Destination coordinate
                        segment2.Text = s;
                        // Add heading to page containing TOC
                        tocPage.Paragraphs.Add(heading2);
                    }
                    doc.Save("Toc_" + DateTime.Now.Millisecond + ".pdf");
                    File.Delete("tmp.pdf");
                    MessageBox.Show("PDF with TOC has been created.", "Success");
                }
                else
                {
                    MessageBox.Show("Please extract titles from PDF document first.", "Titles are not extracted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
