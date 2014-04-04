SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[ClassID] [tinyint] NOT NULL,
	[CreditLine] [decimal](18, 4) NOT NULL,
	[CategoryID] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Nation] [nvarchar](50) NULL,
	[Telphone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Bank] [nvarchar](100) NULL,
	[BankAccount] [nvarchar](100) NULL,
	[SwiftNO] [nvarchar](50) NULL,
	[Creater] [nvarchar](50) NULL,
	[BusinessMan] [nvarchar](50) NULL,
	[DevelopFrom] [nvarchar](50) NULL,
	[MyID] [nvarchar](50) NULL,
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
	[Company] [nvarchar](200) NULL,
	[InternalID] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[ID] [nvarchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
	[Permission] [varchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenditureType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenditureType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ExpanditureType] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliverySheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliverySheet](
	[ID] [nvarchar](50) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NULL,
	[Linker] [nvarchar](50) NULL,
	[LinkerPhoneCall] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Driver] [nvarchar](50) NULL,
	[DriverMobile] [nvarchar](50) NULL,
	[CarPlate] [nvarchar](50) NULL,
	[IsWithTax] [bit] NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
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
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NULL,
	[Post] [nvarchar](50) NULL,
	[RoleID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductInventoryItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductInventoryItem](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[FromInventory] [bit] NOT NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[InventoryItem] [uniqueidentifier] NULL,
	[InventorySheet] [nvarchar](50) NULL,
	[DeliveryItem] [uniqueidentifier] NULL,
	[DeliverySheet] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductInventoryItem] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerReceivable](
	[ID] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[DeliverySheet] [nvarchar](50) NULL,
	[DeliveryItem] [uniqueidentifier] NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerReceivable_1] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierReceivable](
	[ID] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[SupplierID] [nvarchar](50) NOT NULL,
	[PurchaseID] [nvarchar](50) NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[InventorySheet] [nvarchar](50) NULL,
	[InventoryItem] [uniqueidentifier] NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_SupplierReceivable] PRIMARY KEY CLUSTERED 
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
	[OrderID] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InventoryItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[PurchaseOrder] [nvarchar](50) NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItem](
	[ID] [uniqueidentifier] NOT NULL,
	[OrderID] [nvarchar](50) NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenditureRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenditureRecord](
	[ID] [nvarchar](50) NOT NULL,
	[ExpenditureDate] [datetime] NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Category] [nvarchar](50) NULL,
	[OrderID] [nvarchar](50) NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Request] [nvarchar](50) NULL,
	[Payee] [nvarchar](50) NULL,
	[CheckNum] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerPaymentAssign]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerPaymentAssign](
	[ID] [uniqueidentifier] NOT NULL,
	[PaymentID] [nvarchar](50) NOT NULL,
	[ReceivableID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_CustomerPaymentAssign] PRIMARY KEY CLUSTERED 
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
	[CurrencyType] [nvarchar](50) NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[CheckNum] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerOtherReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerOtherReceivable](
	[ID] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[CurrencyType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[State] [tinyint] NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[ID] [nvarchar](50) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[FinalCustomerID] [nvarchar](50) NULL,
	[WithTax] [bit] NOT NULL,
	[PriceTerm] [nvarchar](50) NOT NULL,
	[CurrencyType] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[ExchangeRate] [decimal](18, 4) NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttachmentHeader]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AttachmentHeader](
	[ID] [uniqueidentifier] NOT NULL,
	[DocumentID] [nvarchar](50) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[UploadDateTime] [datetime] NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Attachment_1] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attachment](
	[ID] [uniqueidentifier] NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductCategory](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Parent] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RelatedCompanyType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RelatedCompanyType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_RelatedCompanyType] PRIMARY KEY CLUSTERED 
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
	[Parent] [nvarchar](50) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PurchaseRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_PurchaseRecord]
AS
SELECT     a.ID, a.PurchaseID, b.SupplierID, a.OrderItem, a.OrderID, a.ProductID, a.Unit, a.Price, a.Count, a.DemandDate, b.Buyer, ISNULL(c.Received, 0) AS Received, b.State, 
                      a.IsComplete, a.Memo
FROM         dbo.PurchaseItem AS a INNER JOIN
                      dbo.PurchaseOrder AS b ON a.PurchaseID = b.ID LEFT OUTER JOIN
                          (SELECT     PurchaseItem, SUM(Count) AS Received
                            FROM          dbo.ProductInventoryItem AS a
                            GROUP BY PurchaseItem) AS c ON a.ID = c.PurchaseItem
' 
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_DeliveryRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_DeliveryRecord]
AS
SELECT     a.ID, a.SheetNo, a.OrderItem, a.OrderID, b.CustomerID, b.WareHouseID, a.ProductID, a.Unit, a.Price, d.Count, c.OperatDate AS DeliveryDate
FROM         dbo.DeliveryItem AS a INNER JOIN
                      dbo.DeliverySheet AS b ON a.SheetNo = b.ID INNER JOIN
                      dbo.DocumentOperation AS c ON a.SheetNo = c.DocumentID AND c.DocumentType = ''DeliverySheet'' INNER JOIN
                          (SELECT     DeliveryItem, SUM(Count) AS Count
                            FROM          dbo.ProductInventoryItem
                            GROUP BY DeliveryItem) AS d ON a.ID = d.DeliveryItem
WHERE     (c.State = 2)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_InventoryRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_InventoryRecord]
AS
SELECT     a.ID, a.SheetNo, a.PurchaseItem, a.PurchaseOrder, a.OrderItem, a.OrderID, a.ProductID, a.Unit, a.Price, b.count, a.Memo, c.OperatDate AS InventoryDate, d.SupplierID, 
                      d.WareHouseID
FROM         dbo.InventoryItem AS a INNER JOIN
                          (SELECT     InventoryItem, SUM(Count) AS count
                            FROM          dbo.ProductInventoryItem
                            GROUP BY InventoryItem) AS b ON a.ID = b.InventoryItem INNER JOIN
                      dbo.DocumentOperation AS c ON a.SheetNo = c.DocumentID AND c.DocumentType = ''InventorySheet'' INNER JOIN
                      dbo.InventorySheet AS d ON a.SheetNo = d.ID
WHERE     (c.State = 3)
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItemInventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItemInventory]
AS
SELECT     OrderItem, SUM(CASE WHEN DeliveryItem IS NULL THEN count ELSE 0 END) AS Inventory, SUM(CASE WHEN PurchaseItem IS NULL THEN 0 ELSE count END) 
                      AS Received, SUM(CASE WHEN DeliveryItem IS NULL THEN 0 ELSE count END) AS Shipped
FROM         dbo.ProductInventoryItem AS a
WHERE     (OrderItem IS NOT NULL)
GROUP BY OrderItem
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_ProductInventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_ProductInventory]
AS
SELECT     NEWID() AS ID, ProductID, WareHouseID, Unit, SUM(CASE WHEN OrderItem IS NULL THEN Count ELSE 0 END) AS Valid, SUM(CASE WHEN OrderItem IS NULL 
                      THEN Count * price ELSE 0 END) AS ValidAmount, SUM(CASE WHEN OrderItem IS NULL THEN 0 ELSE Count END) AS Reserved, SUM(CASE WHEN OrderItem IS NULL 
                      THEN 0 ELSE count * price END) AS ReservedAmount
FROM         dbo.ProductInventoryItem AS a
WHERE     (DeliveryItem IS NULL)
GROUP BY ProductID, WareHouseID, Unit
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Order]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_Order]
AS
SELECT     a.ID, a.CustomerID, a.FinalCustomerID, a.WithTax, a.PriceTerm, a.CurrencyType, a.Symbol, a.ExchangeRate, a.CollectionType, a.Transport, a.LoadPort, 
                      a.DestinationPort, a.CanBatch, a.CanRelay, a.Mark, a.OrderDate, a.DemandDate, a.SalesPerson, a.State, a.Memo, ISNULL(b.Receivable, 0) AS Receivable, 
                      ISNULL(c.Paid, 0) AS HasPaid, ISNULL(d.Expenditure, 0) AS Expenditure
FROM         dbo.[Order] AS a LEFT OUTER JOIN
                          (SELECT     OrderID, SUM(Amount) AS Receivable
                            FROM          dbo.CustomerReceivable
                            GROUP BY OrderID) AS b ON a.ID = b.OrderID LEFT OUTER JOIN
                          (SELECT     ReceivableID AS OrderID, SUM(Amount) AS Paid
                            FROM          dbo.CustomerPaymentAssign
                            GROUP BY ReceivableID) AS c ON a.ID = c.OrderID LEFT OUTER JOIN
                          (SELECT     OrderID, SUM(Amount) AS Expenditure
                            FROM          dbo.ExpenditureRecord
                            WHERE      (State <> 5)
                            GROUP BY OrderID) AS d ON a.ID = d.OrderID
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_CustomerOtherReceivable]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_CustomerOtherReceivable]
AS
SELECT     a.ID, a.CreateDate, a.CustomerID, a.OrderID, a.CurrencyType, a.Amount, ISNULL(b.Paid, 0) AS Paid, a.State, a.Memo
FROM         dbo.CustomerOtherReceivable AS a LEFT OUTER JOIN
                          (SELECT     ReceivableID, SUM(Amount) AS Paid
                            FROM          dbo.CustomerPaymentAssign
                            GROUP BY ReceivableID) AS b ON a.ID = b.ReceivableID
' 
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
                            FROM          dbo.InventoryItem AS a INNER JOIN
                                                   dbo.InventorySheet AS b ON a.SheetNo = b.ID
                            WHERE      (b.State = 3)
                            GROUP BY a.PurchaseItem) AS c ON a.ID = c.PurchaseItem
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItem]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItem]
AS
SELECT     a.ID, a.OrderID, a.ProductID, a.ProductCode, a.Unit, a.Price, a.Count, ISNULL(c.Purchased, 0) AS Purchased, ISNULL(d.Received, 0) AS Received, ISNULL(d.Inventory, 
                      0) AS Inventory, ISNULL(d.Shipped, 0) AS Shipped, a.DemandDate, a.IsComplete, a.Memo
FROM         dbo.OrderItem AS a LEFT OUTER JOIN
                      dbo.View_OrderItemPurchase AS c ON a.ID = c.OrderItem LEFT OUTER JOIN
                      dbo.View_OrderItemInventory AS d ON a.ID = d.OrderItem
' 
go

if not exists (select * from operator where id='admin')
insert into operator (ID,Name,Password,RoleID) values('admin','admin','123','系统管理员')

if not exists (select * from Role where id='系统管理员')
insert into Role (ID,Description,Permission) values('系统管理员','系统管理员，有系统所有的权限.','all')