<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExtractAllHrefFromHtmlSnippet._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Extracting Hrefs With The HtmlAgilityPack Sample - Run Tings Proper</title>
    <style type="text/css">
        body
        {
            font-family: Arial, "Sans-Serif";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            HtmlAgilityPack Example</h1>
        <p>
            This example shows how to extract all href attributes from a html snippet using
            the HtmlAgilityPack.</p>
        <p>This sample application is explained in full at <a href="http://runtingsproper.blogspot.com/2009/11/easily-extracting-links-from-snippet-of.html">http://runtingsproper.blogspot.com/2009/11/easily-extracting-links-from-snippet-of.html</a>.</p>
        <asp:GridView ID="GridViewHrefs" runat="server" EmptyDataText="No hrefs found">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
