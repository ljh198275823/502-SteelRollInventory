SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[RoleID] [nvarchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
	[Permission] [varchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItemInventory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItemInventory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[OrderItem] [uniqueidentifier] NOT NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[InventorySheetItem] [uniqueidentifier] NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Shipped] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_OrderItemAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliverySheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliverySheet](
	[ID] [nvarchar](50) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[IsWithTax] [bit] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[WareHouseID] [nvarchar](50) NULL,
	[Linker] [nvarchar](50) NULL,
	[LinkerPhoneCall] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Driver] [nvarchar](50) NULL,
	[DriverMobile] [nvarchar](50) NULL,
	[CarPlate] [nvarchar](50) NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[DeadlineDate] [datetime] NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DeliverySheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductCategory](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [nvarchar](50) NOT NULL,
	[SupplierID] [nvarchar](50) NOT NULL,
	[CurrencyType] [nvarchar](50) NOT NULL,
	[WithTax] [bit] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[Buyer] [nvarchar](50) NULL,
	[State] [tinyint] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locker]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locker](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Locker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CollectionType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CollectionType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceTerm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PriceTerm](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](50) NULL,
 CONSTRAINT [PK_PriceTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Unit](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Plural] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrencyType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CurrencyType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[ExchangeRate] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Port]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Port](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsForeign] [bit] NOT NULL,
	[Country] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Port] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transport](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tranport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Operator](
	[OperatorID] [nvarchar](50) NOT NULL,
	[OperatorName] [nvarchar](50) NOT NULL,
	[OperatorPwd] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NULL,
	[Post] [nvarchar](50) NULL,
	[RoleID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RelatedCompany]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RelatedCompany](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CodeNum] [int] NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[Linker] [nvarchar](50) NULL,
	[TelPhone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](200) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[QQ] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Website] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[BankInfo] [nvarchar](200) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_RalateCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[OperatorID] [nvarchar](50) NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[Value] [ntext] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC,
	[Key] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attachment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentID] [nvarchar](50) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[UploadDateTime] [datetime] NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[Value] [image] NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[ShortName] [nvarchar](50) NULL,
	[CategoryID] [nvarchar](50) NOT NULL,
	[BarCode] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Specification] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[HSCode] [nvarchar](50) NULL,
	[HSName] [nvarchar](50) NULL,
	[BackTaxes] [decimal](18, 4) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Nation] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[CategoryID] [nvarchar](50) NULL,
	[Website] [nvarchar](100) NULL,
	[Telphone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Bank] [nvarchar](100) NULL,
	[BankAccount] [nvarchar](100) NULL,
	[SwiftNO] [nvarchar](50) NULL,
	[CreditLine] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NOT NULL,
	[TelPhone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[QQ] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Supplier](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Nation] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[CategoryID] [nvarchar](50) NULL,
	[Website] [nvarchar](100) NULL,
	[Telphone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Bank] [nvarchar](100) NULL,
	[BankAccount] [nvarchar](100) NULL,
	[SwiftNO] [nvarchar](50) NULL,
	[CreditLine] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenditureRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenditureRecord](
	[ID] [nvarchar](50) NOT NULL,
	[ExpenditureDate] [datetime] NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateOperator] [nvarchar](50) NOT NULL,
	[CancelDate] [datetime] NULL,
	[CancelOperator] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK__ExpenditureRecor__29572725] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[ID] [nvarchar](50) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[WithTax] [bit] NOT NULL,
	[PriceTerm] [nvarchar](50) NOT NULL,
	[CurrencyType] [nvarchar](50) NOT NULL,
	[CollectionType] [nvarchar](50) NOT NULL,
	[Transport] [nvarchar](50) NOT NULL,
	[LoadPort] [nvarchar](50) NULL,
	[DestinationPort] [nvarchar](50) NULL,
	[CanBatch] [bit] NOT NULL,
	[CanRelay] [bit] NOT NULL,
	[Mark] [nvarchar](50) NULL,
	[OrderDate] [datetime] NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoCreateNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AutoCreateNumber](
	[Prefix] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[NumberType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AutoCreateNumber] PRIMARY KEY CLUSTERED 
(
	[Prefix] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_DeliverySheetItem]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_DeliverySheetItem] AS SELECT     a.ID, a.SheetNo, a.ProductID, a.Unit, a.Price, a.Count, ISNULL(b.Cost, 0) AS Cost, a.Memo, a.OrderID FROM         dbo.DeliverySheetItem AS a LEFT OUTER JOIN                           (SELECT     t1.DeliveryItem, SUM(t1.Count * t2.Price) AS Cost                             FROM          dbo.InventoryItemAssign AS t1 INNER JOIN                                                    dbo.InventoryItem AS t2 ON t1.InventoryItem = t2.ID                             GROUP BY t1.DeliveryItem) AS b ON a.ID = b.DeliveryItem ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[31] 4[39] 2[16] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 177             End             DisplayFlags = 280             TopColumn = 0          End          Begin Table = "b"             Begin Extent =                 Top = 294                Left = 38                Bottom = 407                Right = 188             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliverySheetItem'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliverySheetItem'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_SupplierType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItemInventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItemInventory]
AS
SELECT     OrderItem, SUM(Count) AS Inventory, SUM(CASE PurchaseItem WHEN NULL THEN 0 ELSE count END) AS Received, SUM(Shipped) AS Shipped
FROM         dbo.OrderItemInventory AS a
GROUP BY OrderItem
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItemInventory'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItemInventory'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDaiFu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerDaiFu](
	[ID] [nvarchar](50) NOT NULL,
	[DaiFuDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateOperator] [nvarchar](50) NOT NULL,
	[CancelDate] [datetime] NULL,
	[CancelOperator] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK__DaiFuRecord__2B3F6F97] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerPayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerPayment](
	[ID] [nvarchar](50) NOT NULL,
	[PaidDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[CheckNum] [nvarchar](50) NULL,
	[SheetNo] [nvarchar](50) NULL,
	[IsPrepay] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateOperator] [nvarchar](50) NOT NULL,
	[CancelDate] [datetime] NULL,
	[CancelOperator] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sysparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sysparameter](
	[Parameter] [varchar](50) NOT NULL,
	[ParameterValue] [text] NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_Sysparameter] PRIMARY KEY CLUSTERED 
(
	[Parameter] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerReceivable](
	[ID] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerReceivable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerPaymentAssign]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerPaymentAssign](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentID] [nvarchar](50) NOT NULL,
	[ReceivableID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_PaymentAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductInventory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductInventory](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[WarehouseID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_ProductInventory_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItem](
	[ID] [uniqueidentifier] NOT NULL,
	[OrderID] [nvarchar](50) NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[IsComplete] [bit] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseItem](
	[ID] [uniqueidentifier] NOT NULL,
	[PurchaseID] [nvarchar](50) NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[IsComplete] [bit] NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PurchaseSheetItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventorySheetItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InventorySheetItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_InventorySheetItem_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DeliverySheetItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DocumentOperation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DocumentOperation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentID] [nvarchar](50) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[OperatDate] [datetime] NOT NULL,
	[Operation] [nvarchar](200) NOT NULL,
	[State] [tinyint] NOT NULL,
	[Operator] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DocumentOperation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventorySheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InventorySheet](
	[ID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NOT NULL,
	[SupplierID] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_InventorySheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WareHouse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WareHouse](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_CustomerDaiFu]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_CustomerDaiFu] AS SELECT     a.ID, a.DaiFuDate, a.CustomerID, a.PaymentMode, a.Amount, a.CreateDate, a.CreateOperator, a.CancelDate, a.CancelOperator, a.Memo, ISNULL(b.Paid, 0)                        AS Paid FROM         dbo.CustomerDaiFu AS a LEFT OUTER JOIN                           (SELECT     ReceivableID, SUM(Amount) AS Paid                             FROM          dbo.CustomerPaymentAssign                             GROUP BY ReceivableID) AS b ON a.ID = b.ReceivableID ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[40] 4[20] 2[20] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 204             End             DisplayFlags = 280             TopColumn = 0          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 242                Bottom = 95                Right = 394             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerDaiFu'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerDaiFu'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_CustomerPaymentAssign]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_CustomerPaymentAssign] AS SELECT     b.ID, b.PaymentID, a.PaidDate, a.CustomerID, a.PaymentMode, a.CheckNum, a.SheetNo, a.IsPrepay, a.Amount, b.ReceivableID, b.Amount AS Assign FROM         dbo.CustomerPayment AS a INNER JOIN                       dbo.CustomerPaymentAssign AS b ON a.ID = b.PaymentID ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[10] 4[65] 2[9] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 207                Right = 204             End             DisplayFlags = 280             TopColumn = 4          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 242                Bottom = 125                Right = 394             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerPaymentAssign'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerPaymentAssign'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_CustomerPayment]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_CustomerPayment] AS SELECT     a.ID, a.PaidDate, a.CustomerID, a.PaymentMode, a.Amount, a.Amount - ISNULL(b.HasPaid, 0) AS Remain, a.CheckNum, a.SheetNo, a.IsPrepay, a.CreateDate,                        a.CreateOperator, a.CancelDate, a.CancelOperator, a.Memo FROM         dbo.CustomerPayment AS a LEFT OUTER JOIN                           (SELECT     PaymentID, SUM(Amount) AS HasPaid                             FROM          dbo.CustomerPaymentAssign                             GROUP BY PaymentID) AS b ON a.ID = b.PaymentID ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[40] 4[20] 2[20] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 204             End             DisplayFlags = 280             TopColumn = 0          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 242                Bottom = 95                Right = 384             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerPayment'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerPayment'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_CustomerReceivable]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_CustomerReceivable] AS SELECT     a.ID, a.CreateDate, a.CustomerID, a.Amount, ISNULL(b.Paid, 0) AS Paid, a.Amount - ISNULL(b.Paid, 0) AS Receivable, a.Memo FROM         dbo.CustomerReceivable AS a LEFT OUTER JOIN                           (SELECT     ReceivableID, SUM(Amount) AS Paid                             FROM          dbo.CustomerPaymentAssign                             GROUP BY ReceivableID) AS b ON a.ID = b.ReceivableID ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[40] 4[20] 2[20] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 184             End             DisplayFlags = 280             TopColumn = 0          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 222                Bottom = 95                Right = 374             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerReceivable'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_CustomerReceivable'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_DeliverySheet]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_DeliverySheet] AS SELECT     a.ID, a.CustomerID, a.CustomerName, a.Linker, a.LinkerPhoneCall, a.Address, a.WareHouseID, a.WareHouseName, a.Driver, a.CarPlate, a.DriverMobile, a.IsWithTax,                        a.Amount, a.Discount, a.ReturnBack, a.DeadlineDate, a.State, a.SalesPerson, a.OrderID, a.CreateDate, a.CreateOperator, a.ApproveDate, a.ApproveOperator,                        a.DeliveryDate, a.DeliveryOperator, a.CancelDate, a.CancelOperator, a.Memo, ISNULL(b.Paid, 0) AS Paid FROM         dbo.DeliverySheet AS a LEFT OUTER JOIN                           (SELECT     ReceivableID, SUM(Amount) AS Paid                             FROM          dbo.CustomerPaymentAssign                             GROUP BY ReceivableID) AS b ON a.ID = b.ReceivableID ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[22] 4[39] 2[21] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 212             End             DisplayFlags = 280             TopColumn = 17          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 250                Bottom = 95                Right = 402             End             DisplayFlags = 280             TopColumn = 0          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliverySheet'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliverySheet'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PurchaseOrder]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_PurchaseOrder]
AS
SELECT     ID, SupplierID, CurrencyType, WithTax, OrderDate, DemandDate, Buyer, State, Memo
FROM         dbo.PurchaseOrder
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PurchaseOrder"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseOrder'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseOrder'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItemPurchase]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItemPurchase]
AS
SELECT     a.OrderItem, SUM(a.Count) AS Purchased
FROM         dbo.PurchaseItem AS a INNER JOIN
                      dbo.PurchaseOrder AS b ON a.PurchaseID = b.ID
WHERE     (b.State <> 5) AND (a.OrderItem IS NOT NULL)
GROUP BY a.OrderItem
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[24] 4[22] 2[26] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 231
               Bottom = 125
               Right = 404
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1485
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItemPurchase'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItemPurchase'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PurchaseRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_PurchaseRecord]
AS
SELECT     a.ID, a.SheetNo, b.SupplierID, a.OrderItem, a.OrderID, a.ProductID, a.Unit, a.Price, a.Count, a.DemandDate, b.Buyer, ISNULL(c.Received, 0) AS Received, b.State, 
                      a.IsComplete, a.Memo
FROM         dbo.PurchaseSheetItem AS a INNER JOIN
                      dbo.PurchaseSheet AS b ON a.SheetNo = b.ID LEFT OUTER JOIN
                          (SELECT     a.PurchaseItem, SUM(a.Count) AS Received
                            FROM          dbo.InventorySheetItem AS a INNER JOIN
                                                   dbo.InventorySheet AS b ON a.SheetNo = b.ID
                            WHERE      (b.State = 3)
                            GROUP BY a.PurchaseItem) AS c ON a.ID = c.PurchaseItem
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[49] 2[2] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 125
               Right = 384
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 422
               Bottom = 107
               Right = 577
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseRecord'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseRecord'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Order]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_Order]
AS
SELECT     ID, CustomerID, WithTax, PriceTerm, CurrencyType, CollectionType, Transport, LoadPort, DestinationPort, CanBatch, CanRelay, Mark, OrderDate, DemandDate, 
                      SalesPerson, State, Memo
FROM         dbo.[Order]
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Order"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 201
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_Order'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_Order'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_DeliveryRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_DeliveryRecord] AS SELECT     b.ID, a.ID AS SheetNo, a.CustomerID, a.CustomerName, a.WareHouseID, a.DeliveryDate, a.SalesPerson, a.IsWithTax, a.OrderID, b.ProductID, b.Unit, b.Price, b.Count,                        b.Cost FROM         dbo.DeliverySheet AS a INNER JOIN                       dbo.View_DeliverySheetItem AS b ON a.ID = b.SheetNo WHERE     (a.State = 2) ' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00] Begin DesignProperties =     Begin PaneConfigurations =        Begin PaneConfiguration = 0          NumPanes = 4          Configuration = "(H (1[31] 4[44] 2[19] 3) )"       End       Begin PaneConfiguration = 1          NumPanes = 3          Configuration = "(H (1 [50] 4 [25] 3))"       End       Begin PaneConfiguration = 2          NumPanes = 3          Configuration = "(H (1 [50] 2 [25] 3))"       End       Begin PaneConfiguration = 3          NumPanes = 3          Configuration = "(H (4 [30] 2 [40] 3))"       End       Begin PaneConfiguration = 4          NumPanes = 2          Configuration = "(H (1 [56] 3))"       End       Begin PaneConfiguration = 5          NumPanes = 2          Configuration = "(H (2 [66] 3))"       End       Begin PaneConfiguration = 6          NumPanes = 2          Configuration = "(H (4 [50] 3))"       End       Begin PaneConfiguration = 7          NumPanes = 1          Configuration = "(V (3))"       End       Begin PaneConfiguration = 8          NumPanes = 3          Configuration = "(H (1[56] 4[18] 2) )"       End       Begin PaneConfiguration = 9          NumPanes = 2          Configuration = "(H (1 [75] 4))"       End       Begin PaneConfiguration = 10          NumPanes = 2          Configuration = "(H (1[66] 2) )"       End       Begin PaneConfiguration = 11          NumPanes = 2          Configuration = "(H (4 [60] 2))"       End       Begin PaneConfiguration = 12          NumPanes = 1          Configuration = "(H (1) )"       End       Begin PaneConfiguration = 13          NumPanes = 1          Configuration = "(V (4))"       End       Begin PaneConfiguration = 14          NumPanes = 1          Configuration = "(V (2))"       End       ActivePaneConfig = 0    End    Begin DiagramPane =        Begin Origin =           Top = 0          Left = 0       End       Begin Tables =           Begin Table = "a"             Begin Extent =                 Top = 6                Left = 38                Bottom = 125                Right = 212             End             DisplayFlags = 280             TopColumn = 0          End          Begin Table = "b"             Begin Extent =                 Top = 6                Left = 250                Bottom = 153                Right = 389             End             DisplayFlags = 280             TopColumn = 2          End       End    End    Begin SQLPane =     End    Begin DataPane =        Begin ParameterDefaults = ""       End    End    Begin CriteriaPane =        Begin ColumnWidths = 11          Column = 1440          Alias = 900          Table = 1170          Output = 720          Append = 1400          NewValue = 1170          SortType = 1350          SortOrder = 1410          GroupBy = 1350          Filter = 1350          Or = 1350          Or = 1350          Or = 1350       End    End End ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliveryRecord'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_DeliveryRecord'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PurchaseItem]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_PurchaseItem]
AS
SELECT     a.ID, a.PurchaseID, a.OrderID, a.OrderItem, a.ProductID, a.Unit, a.Price, a.Count, a.IsComplete, a.DemandDate, a.Memo, ISNULL(c.Received, 0) AS Received
FROM         dbo.PurchaseItem AS a LEFT OUTER JOIN
                          (SELECT     a.PurchaseItem, SUM(a.Count) AS Received
                            FROM          dbo.InventorySheetItem AS a INNER JOIN
                                                   dbo.InventorySheet AS b ON a.SheetNo = b.ID
                            WHERE      (b.State = 3)
                            GROUP BY a.PurchaseItem) AS c ON a.ID = c.PurchaseItem
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 95
               Right = 382
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseItem'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_PurchaseItem'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItem]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItem]
AS
SELECT     a.ID, a.OrderID, a.ProductID, a.Unit, a.Price, a.Count, a.DemandDate, a.IsComplete, a.Memo, ISNULL(c.Purchased, 0) AS Purchased, ISNULL(d.Received, 0) 
                      AS Received, ISNULL(d.Inventory, 0) AS Inventory, ISNULL(d.Shipped, 0) AS Shipped
FROM         dbo.OrderItem AS a LEFT OUTER JOIN
                      dbo.View_OrderItemPurchase AS c ON a.ID = c.OrderItem LEFT OUTER JOIN
                      dbo.View_OrderItemInventory AS d ON a.ID = d.OrderItem
' 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 239
               Bottom = 205
               Right = 390
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 177
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 428
               Bottom = 110
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItem'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'View_OrderItem'
go


if not exists (select * from operator where operatorid='admin')
insert into operator (operatorID,OperatorName,OperatorPwd,RoleID) values('admin','admin','123','系统管理员')

if not exists (select * from Role where roleid='系统管理员')
insert into Role (RoleID,Description,Permission) values('系统管理员','系统管理员，有系统所有的权限.','all')