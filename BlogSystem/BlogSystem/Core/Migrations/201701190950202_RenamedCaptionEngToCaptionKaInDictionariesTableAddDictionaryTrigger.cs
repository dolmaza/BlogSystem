namespace Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenamedCaptionEngToCaptionKaInDictionariesTableAddDictionaryTrigger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dictionaries", "CaptionKa", c => c.String(maxLength: 200));
            DropColumn("dbo.Dictionaries", "CaptionEng");

            Sql("CREATE  TRIGGER [dbo].[OnDictionariesHierarchyCalc] ON [dbo].[Dictionaries] FOR INSERT, UPDATE AS DECLARE @DEL bit = 0 DECLARE @INS bit  = 0 DECLARE @numrows int = @@rowcount DECLARE @Delimiter varchar(1) = '.' IF EXISTS (SELECT TOP 1 1 FROM DELETED) SET @DEL=1 IF EXISTS (SELECT TOP 1 1 FROM INSERTED) SET @INS = 1  IF @INS = 0 AND @DEL = 0 RETURN IF @INS = 1 AND @DEL = 0 BEGIN IF @numrows > 1 BEGIN RAISERROR('Only single row inserts are supported!', 16, 1) ROLLBACK TRAN RETURN END ELSE BEGIN UPDATE D SET D.[Level] = CASE WHEN D.ParentID IS NULL THEN 0 ELSE D1.[Level] + 1 END, D.Hierarchy = CASE WHEN D.ParentID IS NULL THEN @Delimiter ELSE D1.Hierarchy END + CAST(D.ID AS varchar(10)) + @Delimiter FROM Dictionaries D INNER JOIN inserted I ON I.ID = D.ID LEFT JOIN Dictionaries D1 ON D.ParentID = D1.ID END END ELSE BEGIN IF UPDATE(ID) BEGIN RAISERROR('Updates to codeid not allowed!', 16, 1) ROLLBACK TRAN RETURN END ELSE BEGIN IF UPDATE(ParentID) or UPDATE(StringCode) BEGIN UPDATE D SET D.[Level] = D.[Level] - I.[Level] + CASE WHEN I.ParentID IS NULL THEN 0 ELSE D1.[Level] + 1 END, D.Hierarchy = ISNULL(D1.Hierarchy, '.') + CAST(I.ID AS varchar(10)) + '.' + ISNULL(RIGHT(D.Hierarchy, LEN(D.Hierarchy) - LEN(I.Hierarchy)), '') FROM Dictionaries D INNER JOIN INSERTED I ON D.Hierarchy LIKE I.Hierarchy + '%' LEFT JOIN Dictionaries D1 ON I.ParentID = D1.ID END END END");

        }

        public override void Down()
        {
            Sql("DROP TRIGGER [OnDictionariesHierarchyCalc]");

            AddColumn("dbo.Dictionaries", "CaptionEng", c => c.String(maxLength: 200));
            DropColumn("dbo.Dictionaries", "CaptionKa");


        }
    }
}
