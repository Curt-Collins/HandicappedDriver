<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="useReservation.aspx.cs" Inherits="HandicappedDriver.useReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="useReservation" runat="server">
        <div>
            <asp:Label CssClass="lblReservation" ID="lblUserReservation" runat="server" placeholder="Your reservation" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnOccupy" runat="server" Text="Occupy" OnClick="btnOccupy_Click" />
            <asp:Button ID="btnLeave" runat="server" Text="Leave" OnClick="btnLeave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

            <br />
            <br />
            <asp:Button ID="btnNavigate" runat="server" Text="Navigate" OnClick="btnNavigate_Click" />
        </div>
        
    </form>
</body>
</html>
