<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="Home.aspx.cs" Inherits="Website.Presentation.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">

    <asp:Panel runat="server" CssClass="startupControllers">
        <div class="row">
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <div class="caption">
                        <h4>What is your name</h4>
                        <asp:TextBox runat="server" ID="TxtName"  />
                        <h4>What is the scan radius? (km)</h4>
                        <asp:TextBox runat="server" ID="TxtRadius"  TextMode="Number" min="1" />
                        <br />
                        <p>
                            <asp:LinkButton runat="server" OnClick="SaveNameAndRadius" Text="Start" class="btn btn-primary" role="button"></asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <div class="caption">
                        <h4>Use Facebook to Login</h4>
                        <asp:Button ID="btnLogin" runat="server" Text="Login with FaceBook" OnClick="Login" />
                        <h4>What is the scan radius? (km)(default 10)</h4>
                        <asp:TextBox runat="server" ID="TxtRadiusFacebook" TextMode="Number" min="1" />
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>

<asp:Content ID="HiddenContent" ContentPlaceHolderID="HiddenPlaceholder" runat="server">
    <div>
        <asp:HiddenField runat="server" ID="Latitude" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="Longitude" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="GroupId" ClientIDMode="Static" />
    </div>
</asp:Content>