<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="HandicappedDriver.homePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">
        body {
            background: #036ffc;
            font-size: 25px;
        }

        .nav-link {
            color: ghostwhite;
            font-size: 20px;
            position:absolute;
            right: 2%;
            top: 2%;
        }

        .nav-link:hover {
            font-style: oblique;
            color: #191919;
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

        .btn{
            background-color: darkslategrey;
            border-radius: 7px;
            /*height: 2em;
            width: 7em;*/
            font-size: 15px;
            text-align: center;
            margin: 10px 10px 10px 10px;
        }
        
        .btn:hover{
            height: 3em;
            width: 8em;
            font-size: 15px;
            text-align: center;
            transition: 0.25s;
        }

        div{
            margin: 50px 20px 50px 20px;
            border-radius:12px;
        }
    </style>


    <form id="logout" runat="server">
        <div>
            <asp:HyperLink class="nav-link" ID="hpLogout" NavigateUrl="loginPage.aspx" runat="server">Logout</asp:HyperLink>
        </div>



        <div class="container">

    <div class="card-deck">
        <div class="card" style="background-color: #ED6A5A">
            <div>
                <h5><u>Update profile</u></h5>
                <p>To access and update your profile information, click the button below.</p>
                <asp:Button CssClass="btn" ID="btnUpdateProfile" runat="server" Text="Update profile" OnClick="btnUpdateProfile_Click" />
            </div>
        </div>

        <div class="card" style="background-color: #F4F1BB">
            <div>
                <h5><u>View Available</u></h5>
                <p>To view available spaces, click the button below.</p>
                <asp:Button CssClass="btn" ID="btnViewAvailable" runat="server" Text="View available" OnClick="btnViewAvailable_Click" />
            </div>
        </div>

        <div class="card" style="background-color: #9BC1BC">
            <div>
                <h5><u>Show reservation</u></h5>
                <p>To view your reservation, click the button below.</p>
                <asp:Button CssClass="btn" ID="btnUseReservation" runat="server" Text="Show reservation" OnClick="btnUseReservation_Click" />
            </div>
        </div>

        <div class="card" style="background-color: #5CA4A9">
            <div>
                <h5><u>Message driver</u></h5>
                <p>To message a driver who is in your spot, click the button below.</p>
                <asp:Button CssClass="btn" ID="btnMessageDriver" runat="server" Text="Message driver" OnClick="btnMessageDriver_Click" />
            </div>
        </div>

    </div>
</div>




    </form>



</body>
</html>
