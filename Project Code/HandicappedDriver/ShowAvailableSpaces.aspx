<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAvailableSpaces.aspx.cs" Inherits="HandicappedDriver.ShowAvailableSpaces" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="true" Width="100%">
                <Columns>
                    <asp:BoundField DataField="LocationDesc" HeaderText="Space" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="FromTime" HeaderText="From" />
                                <asp:BoundField DataField="UntilTime" HeaderText="To" />
                            </Columns>
                        </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
