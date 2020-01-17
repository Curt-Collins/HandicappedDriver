<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="HandicappedDriver.createAccount" %>

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

        #createDriver{
            height: inherit;
            padding-top: 50px;
            padding-left: 40px;
            padding-right: 40px;
            padding-bottom: 50px;
            margin-left: 150px;
            margin-right: 150px;
            margin-bottom: 20px;
            position: center;
            text-align: center;
            background: #191919;
            border-radius: 20px;
        }

        .txtInput{
            border: 0;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            padding: 14px 10px;
            width: 280px;
            border-radius:10px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
        }

        .txtInput:focus{
            width: 320px;
            border-color: #2ecc71;
        }

        .reg-state{
            
            border: 0;
            background: black;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            padding: 14px 10px;
            width: 280px;
            border-radius:10px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
        }

        .reg-state:focus{
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
            transition: 0.25s;
            cursor: pointer;
        }

        .btn:hover {
            background: #2ecc71;
        }
        
        #txtInput{
            border: 0;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            padding: 14px 10px;
            width: 280px;
            border-radius:10px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
        }

        #txtInput:focus{
            width: 320px;
            border-color: #2ecc71;
        }

        
    </style>



    <form  id="createDriver" runat="server">
        <div>
            
            <asp:TextBox CssClass="txtInput" ID="txtUserName" runat="server" placeholder="Username"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqUName" controltovalidate="txtUserName" errormessage="This field is required" BackColor="White" BorderColor="#FF0066"/>

            <asp:TextBox CssClass="txtInput" ID="txtPhoneNumber" runat="server" placeholder="Phone Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqPhNum" controltovalidate="txtPhoneNumber" errormessage="This field is required" BackColor="White" BorderColor="#FF0066" />

            <br />
            <asp:DropDownList CssClass="reg-state" ID="drpRegState" runat="server"></asp:DropDownList>
   
            <br />
            <asp:TextBox CssClass="txtInput" ID="txtRegNumber" runat="server" placeholder="Vehicle Registration Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqRegNum" controltovalidate="txtRegNumber" errormessage="This field is required" BackColor="White" BorderColor="#FF0066"/>

            
            <br />
            <asp:TextBox CssClass="txtInput" ID="txtPass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqPass" controltovalidate="txtPass" errormessage="This field is required" BackColor="White" BorderColor="#FF0066"/>


            <br />
            <asp:Button CssClass="btn" ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" />
            <br />


            <%--<asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" style="margin-right:10px"/>
            <asp:Button ID="btnForgotPass" runat="server" Text="Forgot password?" OnClick="btnForgotPass_Click" style="margin-left:10px; margin-right:10px;"/>
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" style="margin-left:10px;" />--%>

            
        </div>
    </form>
</body>
</html>
