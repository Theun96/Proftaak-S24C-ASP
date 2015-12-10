<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="Techniek.aspx.cs" Inherits="ICT4Rails.Techniek" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
<script>
    $( "#Date" ).datepicker();
</script>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <table class="table table-striped" style="width: 100%;">
            <thead>
                <tr>
                    <th>Tram</th>
                    <th>Begin datum</th>
                    <th>Eind datum</th>
                    <th>Technicus</th>
                    <th>Klaar</th>
                    <th>Opmerking</th>
                </tr>
            </thead>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
        <div class="col-md-3  col-md-offset-1">
            <asp:DropDownList ID="DropDownUsers" runat="server" cssclass="form-control dropdown"></asp:DropDownList>
            <asp:Button ID="ButtonRepaired" runat="server" Text="Gerepareerd" cssclass="form-control" />
        </div>
        <div class="col-md-3  col-md-offset-4">
            <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>
            <asp:Button ID="ButtonSaveEndDate" runat="server" Text="Einddatum opslaan" cssclass="form-control" />
        </div>
    </div>
   
    <script>
        $(document).ready(function () {
            $("#Date").datepicker();
        });
    </script>
</asp:Content>
