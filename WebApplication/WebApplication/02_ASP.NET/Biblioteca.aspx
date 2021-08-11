<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Biblioteca.aspx.cs" Inherits="WebApplication._02_ASP.NET.Biblioteca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Biblioteca Online</title>
    <link href="../Content/CSS/Biblioteca.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>BiblioTech</h1>
        <h3>Cadastro de Livros </h3>
        <br />
        <div id="campos">
            <div id="campos1" >
                <asp:Label ID="Label_txtIDLivro" runat="server" Text="ID:"></asp:Label>
                <asp:TextBox type="number" ID="txtIDLivro" runat="server" ReadOnly="True"></asp:TextBox>
            
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            </div>
            <div id="campos2" >
                <div>
                    <asp:Label ID="Label_txtTitulo" runat="server" Text="Título:"></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" MaxLength="100"></asp:TextBox>
                </div>
                <div id="divAutor">
                    <asp:Label ID="Label_txtAutor" runat="server" Text="Autor: "></asp:Label>
                    <asp:TextBox ID="txtAutor" runat="server" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div id="campos3" >
                <div>
                    <asp:Label ID="Label_txtAno" runat="server" Text="Ano:"></asp:Label>
                    <asp:TextBox type="number" ID="txtAno" runat="server" min="1" max="2020" step="1"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label_txtEdicao" runat="server" Text="Edição:"></asp:Label>
                    <asp:TextBox type="number" ID="txtEdicao" runat="server" min="1" max="1000" step="1"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label_txtEditora" runat="server" Text="Editora:"></asp:Label>
                    <asp:TextBox ID="txtEditora" runat="server" MaxLength="100"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label_txtIdioma" runat="server" Text="Idioma:"></asp:Label>
                    <asp:TextBox ID="txtIdioma" runat="server"  MaxLength="100"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div>
            <asp:Label ID="lbnMsg" runat="server"></asp:Label>
        </div>
        <br />
        <div id="div-table">
            <asp:GridView class="tabLivros" ID="gvLivro" runat="server" AutoGenerateColumns="False" CellPadding="3" Width="755.53px" OnRowDataBound="gvLivro_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        
                <Columns>
                    <asp:TemplateField HeaderText="ID" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="colIDLivro" Text='<%# Eval("idlivro") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Título" ItemStyle-Width="400px">
                        <ItemTemplate>
                            <asp:Label ID="colTitulo" Text='<%# Eval("Titulo") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle Width="400px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Autor" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="colAutor" Text='<%# Eval("Autor") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemDireita" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ano" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="colAno" Text='<%# Eval("Ano") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edição" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="colEdicao" Text='<%# Eval("Edicao") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editora" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="colEditora" Text='<%# Eval("Editora") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Idioma" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="colIdioma" Text='<%# Eval("Idioma") %>' runat="server" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Content/Pictures/edit.png" runat="server" 
                                OnClick="ImgEditar_Click" CommandArgument='<%# Eval("idlivro")  %>' 
                                ToolTip="Editar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Excluir" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Content/Pictures/delete.png" runat="server"
                                OnClick="ImgExcluir_Click" CommandArgument='<%# Eval("idlivro")  %>'
                                ToolTip="Excluir" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="gvHeader" />
                        <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                </Columns>

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#006699" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>
            <br />
            <asp:Label ID="lbnMsgTable" runat="server"></asp:Label>
        </div>
        <br />
    </form>
</body>
</html>
