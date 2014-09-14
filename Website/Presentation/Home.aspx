<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Page.Master" CodeBehind="Home.aspx.cs" Inherits="Website.Presentation.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder" runat="server">

    <asp:Panel runat="server" CssClass="startupControllers">
		<div class="box-wide login-page-box">
			<div class="column-grid">
				<div class="box-two-thirds">
					<h1 class="headline-medium white">Velkommen på ChatZapp</h1>
					<p class="welcome-text white">Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum har ikke alene overlevet fem århundreder, men har også vundet indpas i elektronisk typografi uden væsentlige ændringer. Sætningen blev gjordt kendt i 1960'erne med lanceringen af Letraset-ark, som indeholdt afsnit med Lorem Ipsum, og senere med layoutprogrammer som Aldus PageMaker, som også indeholdt en udgave af Lorem Ipsum.</p>
				</div>
				<div class="box-third">
					<div class="panel-box">
						<div class="caption">
							<h4 class="headline-small">What is your name</h4>
							<asp:TextBox runat="server" ID="TxtName" class="global-input" />
							<h4 class="headline-small">What is the scan radius? (km)</h4>
							<asp:TextBox runat="server" ID="TxtRadius" TextMode="Number" class="global-input" min="1" />
							<asp:LinkButton runat="server" OnClick="SaveNameAndRadius" Text="Start" class="global-button" role="button"></asp:LinkButton>
						</div>
					</div>
					<div class="panel-box">
						<div class="caption">
							<h4 class="headline-small">Use Facebook to Login</h4>
							<asp:LinkButton ID="btnLogin" runat="server" Text="Login with FaceBook" class="global-button fb-login" OnClick="Login" />
							<h4 class="headline-small">What is the scan radius? (km)(default 10)</h4>
							<asp:TextBox runat="server" ID="TxtRadiusFacebook" TextMode="Number" min="1" class="global-input" ToolTip="10"/>
						</div>
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