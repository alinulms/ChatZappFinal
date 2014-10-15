<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiscussionControl.ascx.cs" Inherits="Website.Presentation.Controls.DiscussionControl" %>
<%@ Import Namespace="Website.Model" %>
<div class="box-wide panel-box discussions-list-viewport">
	<asp:Repeater runat="server" ID="DiscussionList" DataSource="<%#GetMessages() %>">
		<HeaderTemplate>
			<ul id="message_<%#GroupId %>" class="list-group">
		</HeaderTemplate>
		<ItemTemplate>
			<li class="list-group-item">
				<asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" ImageUrl="<%#((Message)Container.DataItem).UserImageUrl %>" /> &nbsp; <%# ((Message)Container.DataItem).Author %> - <%# ((Message)Container.DataItem).Text %>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>

<div class="message-container">
    <div class="box-wide">
        <div class="input-group">
            <input type="text" class="form-control message-input" id="message" placeholder="<%#Website.Resources.Y.YourMessage %>">
            <button id="sendmessage" value="Send" class="send-message-button" type="button"><%#Website.Resources.S.Send %></button>
        </div>
    </div>
    <input type="hidden" id="displayname" />
    <input type="hidden" id="discussionId" value="<%#GroupId %>" />
    <asp:HiddenField runat="server" ID="UserName" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="UserImageUrl" ClientIDMode="static" />
</div>
<span id="error"></span>