<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="Home.aspx.cs" Inherits="Website.Presentation.Home" %>
<%@ Import Namespace="Website.Resources" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">

    <asp:Panel runat="server" CssClass="startupControllers">
        <div class="row">
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <div class="caption">
                        <h4><%#Resources.W.WhatIsYourName %></h4>
                        <asp:TextBox runat="server" ID="TxtName"  />
                        <h4><%#Resources.W.WhatIsTheScanRadius %></h4>
                        <asp:TextBox runat="server" ID="TxtRadius" TextMode="Number" min="1" Text="10"/>
                        <br />
                        <p>
                            <asp:LinkButton runat="server" OnClick="SaveNameAndRadius" Text="<%#Resources.S.Start %>" class="btn btn-primary" role="button"></asp:LinkButton>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <div class="caption">
                        <asp:Button ID="btnLogin" runat="server" Text="<%#Resources.F.FacebookLogin %>" OnClick="Login" />
                        <h4><%#Resources.W.WhatIsTheScanRadius %></h4>
                        <asp:TextBox runat="server" ID="TxtRadiusFacebook" TextMode="Number" min="1" Text="10"/>
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