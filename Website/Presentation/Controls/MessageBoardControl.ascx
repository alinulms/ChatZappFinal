<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBoardControl.ascx.cs" Inherits="Website.Presentation.Controls.MessageBoardControl" %>
<%@ Import Namespace="Website.Model" %>
<div class="viewport">
    <asp:Repeater runat="server" ID="Discussions" DataSource="<%#GetMessageBoardDiscussions() %>">
        <HeaderTemplate>
            <ul class="list-group">
        </HeaderTemplate>
        <ItemTemplate>
            <li id="conversation_<%#(((Message)Container.DataItem).GroupId) %>" class="list-group-item">
                <span class="badge"><%# GetMessagesInDiscussion(((Message)Container.DataItem).GroupId) %></span>
                <asp:LinkButton runat="server" OnClick="ShowDiscussion" CommandArgument="<%#((Message)Container.DataItem).GroupId %>">
                        <p>
                          <strong><%#((Message)Container.DataItem).Author %> :</strong>
                          <%#((Message)Container.DataItem).Text %>
                        </p>
                </asp:LinkButton>
                <em>oprettet:</em>
                <%#((Message)Container.DataItem).SendTime.ToString("dd-MM-yyyy  HH:mm") %>
                <span>(<%#((Message)Container.DataItem).Latitude %> | <%#((Message)Container.DataItem).Longitude %>)
                </span>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>