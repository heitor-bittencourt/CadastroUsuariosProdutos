namespace CadastroUsuariosProdutos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OutraMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Produto_ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Produtoes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Produtoes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Produtoes", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Produto_ProdutoId" });
            DropColumn("dbo.Produtoes", "ApplicationUser_Id");
            DropColumn("dbo.Produtoes", "User_Id");
            DropColumn("dbo.AspNetUsers", "Produto_ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Produto_ProdutoId", c => c.Int());
            AddColumn("dbo.Produtoes", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Produtoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Produto_ProdutoId");
            CreateIndex("dbo.Produtoes", "User_Id");
            CreateIndex("dbo.Produtoes", "ApplicationUser_Id");
            AddForeignKey("dbo.Produtoes", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Produtoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Produto_ProdutoId", "dbo.Produtoes", "ProdutoId");
        }
    }
}
