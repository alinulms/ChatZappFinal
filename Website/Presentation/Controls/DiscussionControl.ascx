<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiscussionControl.ascx.cs" Inherits="Website.Presentation.Controls.DiscussionControl" %>
<%@ Import Namespace="Website.Model" %>
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

<div id="discussion_container">
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <input type="text" class="form-control" id="message">
                <span class="input-group-btn">
                    <%--<input type="button" id="sendmessage" value="Send" class="btn btn-default" />--%>
                    <button id="sendmessage" value="Send" class="btn btn-default" type="button">Send</button>
                </span>
            </div>
        </div>
    </div>
    <input type="hidden" id="displayname" />
    <input type="hidden" id="discussionId" value="<%#GroupId %>" />
    <asp:HiddenField runat="server" ID="UserName" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="UserImageUrl" ClientIDMode="static" />
</div>
<span id="error"></span>