<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="RailInformation.aspx.cs" Inherits="ICT4Rails.RailInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="row">

        <div class="col-md-5">

            <div class="jumbotron">
                <div class="btn-width">
                    <asp:Label ID="lblRailBlokkade" runat="server" Text="Blokkeer Spoor:" />
                </div>

                <div class="btn-width">
                    <asp:Button ID="btnRailBlokkeren" runat="server" CssClass="btn-width form-control" Text="Blokkeren" OnClick="btnRailBlokkeren_Click" />
                </div>
            </div>


        </div>

        <div class="col-md-2">
        </div>

        <div class="col-md-5">
            <div class="jumbotron">

                <div class="btn-width">
                    <asp:Label ID="lblTramReserveren" runat="server" Text="Tram Reserveren:" />
                </div>

                <div>
                    <asp:TextBox ID="tbTramReserveren" runat="server" CssClass="btn-width form-control" Text="" />
                </div>

                <div>
                    <asp:Button ID="btnTramReserveren" runat="server" CssClass="btn-width form-control" Text="Reserveren" OnClick="btnTramReserveren_Click" />
                </div>
            </div>

        </div>
        <div class="col-md-12">
            <div class="jumbotron">
                <asp:DropDownList ID="DropDownListReservations" runat="server" Width="100px"></asp:DropDownList>
                <asp:Button ID="btnDeleteReservation" runat="server" Text="Verwijder" CssClass="btn btn-primary" OnClick="btnDeleteReservation_Click" />
            </div>
        </div>

        <asp:Button ID="btnTerug" runat="server" CssClass="form-control" Text="Terug" OnClick="btnTerug_Click" />
    </div>

</asp:Content>
