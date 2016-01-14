<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="InUitRij.aspx.cs" Inherits="ICT4Rails.InUitRij" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col-md-4 col-md-offset-4">
        <!--<asp:Label ID="lblTramNumber" runat="server" Text="Geef een tramnummer in." CssClass="sectorlabel bg-primary" />!-->
        <asp:TextBox runat="server" ID="tbTramNumber" CssClass="sectorlabel bg-primary" Placeholder="Geef een tramnummer in."></asp:TextBox>
    </div>
    <div class="col-md-4 col-md-offset-4">
        <table class="touchpadtable table">
            <tr>
                <td><asp:Button runat="server" ID="number1" Text="1" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number2" Text="2" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number3" Text="3" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="number4" Text="4" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number5" Text="5" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number6" Text="6" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="number7" Text="7" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number8" Text="8" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="number9" Text="9" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="numberClear" Text="Clr" CssClass="btn btn-default touchpadbtn" OnClick="TouchpadClear_Click"/></td>
                <td><asp:Button runat="server" ID="number0" Text="0" CssClass="btn btn-default touchpadbtn" OnClick="Touchpad_Click"/></td>
                <td><asp:Button runat="server" ID="numberEnter" Text="Ent" CssClass="btn btn-default touchpadbtn" OnClick="TouchpadEnter_Click"/></td>
            </tr>
        </table>
        <div class="container">
            <asp:CheckBox ID="CheckDamaged" runat="server" Text="Reparatie nodig" />
            <br/>
            <asp:CheckBox ID="CheckDirty" runat="server" Text="Schoonmaak nodig" />
        </div>
    </div>
</asp:Content>
