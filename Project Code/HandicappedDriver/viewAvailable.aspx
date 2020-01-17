<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAvailable.aspx.cs" Inherits="HandicappedDriver.viewAvailable" %>

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

        img{
            margin-top: 2px;
            border-radius: 5px;
        }
        div{
            margin: 50px 20px 50px 11px;
            border-radius:12px;
        }

        .btn{
            margin: 10px 50px 20px 30px;
            border-radius: 10px;
            height: 30px;
            background-color:deepskyblue;
            border-style:hidden;
            transition: 0.25s;
        }

        .btn:hover{
            
            height: 50px;
            background-color:deepskyblue;
            border-style:hidden;

        }

        .txtInput{
            margin: 10px 20px 10px 20px;
            border-color: black;
            background-color: #FA7921;
            border-radius: 10px;
            height: 25px;
            text-align:center;
        }

    </style>

    <form id="viewAvilable" runat="server">
        <div style="width: 15rem; background-color: #FDE74C">
            <div id="imgPlaceholder1" style="background-color:lightcyan; margin-left:3px; width: 238px; height:301px">
                <asp:Image ID="campusImage" ImageUrl="https://visitedmondok.com/userfiles/image/photos_195_large.jpg" runat="server" Height="301px" Width="238px" />
            </div>
            <h3 style="margin-left: 20px;"><i><u>Campus map</u></i></h3>
            <p style="margin-left: 20px;">Click the button below to view campus map</p>
            <asp:Button CssClass="btn" ID="btnCampusMap" runat="server" Text="Campus map" OnClick="btnCampusMap_Click" />
        </div>




        <div style="width: inherit; background-color: #FDE74C">
            <div id="imgPlaceholder2" style="background-color:lightcyan; margin-left:3px; width: 699px; height:375px">
                <asp:Image ID="parkinglotImg" ImageUrl="https://cdn2.newsok.biz/cache/r960-49deceb2d94b9bd821ff8c1d7df3a40c.jpg" runat="server" Height="372px" Width="704px" />
            </div>
            <h3 style="margin-left: 20px;"><i><u>Reserve your spot now!</u></i></h3>
            <p style="margin-left: 20px;">To reserve your spot, select your desired lot and spot from the dropdown. A list of unavailable time for that specific spot will be shown below. Start time and end time is a required field.</p>
            
            <div>

                <asp:DropDownList CssClass="txtInput" ID="drpLot" runat="server" Width="222px" OnSelectedIndexChanged="drpLot_SelectedIndexChanged"></asp:DropDownList>
                <br />

                <asp:DropDownList CssClass="txtInput" ID="drpSpot" runat="server" Width="175px"></asp:DropDownList>
                <br />
                <asp:Button CssClass="btn" ID="btnGenerate" runat="server" Text="Generate spots" OnClick="btnGenerate_Click" />
                <br />
            
                <asp:TextBox  CssClass="txtInput" ID="txtStartTime" runat="server" placeholder="Start time" TextMode="DateTime"></asp:TextBox>
                <br />
            
                <asp:TextBox  CssClass="txtInput" ID="txtEndTime" runat="server" placeholder="End time" TextMode="DateTime">
                </asp:TextBox>
                <br />
                <br />

               <%-- <asp:Table ID="tblAvailableSpots" CssClass="txtInput" runat="server">
                </asp:Table>--%>
                <asp:GridView ID="grdRes" runat="server"></asp:GridView>
                <asp:Button CssClass="btn" ID="btnReserve" runat="server" Text="Reserve now" OnClick="btnReserve_Click" />

            </div>
            
        </div>



    </form>
</body>
</html>
