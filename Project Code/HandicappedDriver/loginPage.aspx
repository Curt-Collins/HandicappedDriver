<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="HandicappedDriver.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <style type="text/css">
        body{
            background: #036ffc;
            font-size: 25px;
        }

        #loginForm{
            padding-top:20px;
            padding-left: 50px;
            padding-right: 50px;
            padding-bottom: 40px;
            margin-left: 50px;
            margin-right: 50px;
            margin-bottom: 20px;
            margin-top: 180px;
            position: center;
            text-align: center;
            background: #191919;
            border-radius: 20px;
        }

        #loginForm input[type="password"], #loginForm input[type="text"] {
            border: 0;
            font-size: 17px;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            padding: 14px 10px;
            width: 270px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition:0.25s;
        }

        #loginForm input[type="password"]:focus, #loginForm input[type="text"]:focus{
            width: 320px;
            border-color: #2ecc71;
        }

        .btn{
            border: 0;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #2ecc71;
            padding: 14px 40px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition:0.25s;
            cursor: pointer;
        }

        .btn:hover{
            background: #2ecc71;
        }

        body::-webkit-scrollbar {
            width: 10px;
        }

        body::-webkit-scrollbar-track {
            -webkit-box-shadow: inset 0 0 6px #befc03;
            border-radius: 5px;
        }

        body::-webkit-scrollbar-thumb {
            border-radius: 5px;
            background-color: #d39e00;
            outline: 1px solid slategrey;
        }

    </style>

    <form id="loginForm" runat="server">
        <div>
            
            <asp:TextBox ID="txtUsername" runat="server" placeholder="User name"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button CssClass="btn" ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
