USE [mbpipeline]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateAccount]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateAccount]
	-- Add the parameters for the stored procedure here
 @Name nvarchar(max),
 @ParentId int,
 @UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO accounts([name],[role],[parent])
	Values(@Name, @UserId, @ParentId)
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountAllContacts]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAccountAllContacts]
@id int,
@user int
AS
BEGIN
SELECT c.id               AS id, 
       c.name             AS name, 
       c.title            AS title, 
       c.address          AS address, 
       c.address_line2    AS address_line2, 
       c.city             AS city, 
       s.state            AS state, 
       c.zip_code         AS zip_code, 
       c.country          AS country, 
       c.phone_number     AS phone_number, 
       c.secondary_number AS secondary_number, 
       c.email            AS email 
FROM   contacts c 
       LEFT JOIN states s 
               ON s.id = c.state 
       INNER JOIN accounts a 
               ON a.id = c.account 
WHERE  a.role = @user 
       AND a.id = @id  
END






GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountContacts]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAccountContacts]
@id int
AS
BEGIN
	SELECT c.id as id,
       c.name as name, 
       c.title as title, 
       c.address as address, 
       c.address_line2 as address_line2, 
       c.city as city, 
       s.state as state, 
       c.zip_code as zip_code, 
       c.country as country, 
       c.phone_number as phone_number, 
       c.secondary_number as secondary_number, 
       c.email as email 
FROM   contacts c 
       LEFT JOIN states s 
               ON s.id = c.state 
WHERE  c.account = @id
END






GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountDashboards]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAccountDashboards]
@id int
AS
BEGIN
	SELECT a.id as id,
       a.name as name,
       at.account_type as account_type,
       ss.sales_stage as sales_stage,
       a.volume as volume,
       u.unit as units,
       a.account_rank as account_rank,  
       a.revenue as revenue,
       a.visits_per_year as visits_per_year,
	   c.id as contact_id,
       c.name as contact_name,
       p.name as parent
FROM   accounts a 
       LEFT JOIN account_types at 
              ON at.id = a.account_type 
       LEFT JOIN sales_stages ss 
              ON ss.id = a.sales_stage 
       LEFT JOIN units u 
              ON u.id = a.units 
       LEFT JOIN contacts c 
              ON c.id = a.main_contact 
       LEFT JOIN accounts p 
              ON p.id = a.parent 
WHERE  a.role = @id  
END



GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountDetails]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAccountDetails]
@id int,
@user int
AS
BEGIN
	SELECT a.id as id,
       a.name as name,
       at.account_type as account_type,
       ss.sales_stage as sales_stage,
       a.volume as volume,
       u.unit as units,
       a.account_rank as account_rank,  
       a.revenue as revenue,
       a.visits_per_year as visits_per_year,
	   c.id as contact_id,
       c.name as contact_name,
       p.name as parent
FROM   accounts a 
       LEFT JOIN account_types at 
              ON at.id = a.account_type 
       LEFT JOIN sales_stages ss 
              ON ss.id = a.sales_stage 
       LEFT JOIN units u 
              ON u.id = a.units 
       LEFT JOIN contacts c 
              ON c.id = a.main_contact 
       LEFT JOIN accounts p 
              ON p.id = a.parent 
WHERE  a.id = @id  
AND a.role = @user
END







GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountLocations]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAccountLocations]
@accountId int
AS
BEGIN
SELECT c.id               AS id,
	   c.name			  AS name,
       c.address          AS address, 
       c.address_line2    AS address_line2, 
       c.city             AS city, 
       s.state            AS state, 
       c.zip_code        AS zip_code,
	   lt.location_type as location_type
FROM account_locations c
	   LEFT JOIN states s 
               ON s.id = c.state 
       LEFT JOIN accounts a 
               ON a.id = c.account 
	   LEFT JOIN location_types lt
			   ON lt.id = c.location_type
WHERE  a.id = @accountid  
END













GO
/****** Object:  StoredProcedure [dbo].[usp_GetContact]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetContact]
@id int
AS
BEGIN
SELECT c.id               AS id, 
       c.name             AS name, 
       c.title            AS title, 
       c.address          AS address, 
       c.address_line2    AS address_line2, 
       c.city             AS city, 
       s.state_abr            AS state, 
       c.zip_code         AS zip_code, 
       c.country          AS country, 
       c.phone_number     AS phone_number, 
       c.secondary_number AS secondary_number, 
       c.email            AS email,
	   a.role			  AS owner
FROM   contacts c 
       LEFT JOIN states s 
               ON s.id = c.state 
       LEFT JOIN accounts a 
               ON a.id = c.account 
WHERE  c.id = @id  
END







GO
/****** Object:  StoredProcedure [dbo].[usp_GetLocation]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetLocation]
@accountId int,
@id int
AS
BEGIN
SELECT c.id               AS id,
	   c.name			  AS name,
       c.address          AS address, 
       c.address_line2    AS address_line2, 
       c.city             AS city, 
       s.state            AS state, 
       c.zip_code        AS zip_code,
	   lt.location_type as location_type
FROM account_locations c
	   LEFT JOIN states s 
               ON s.id = c.state 
       LEFT JOIN accounts a 
               ON a.id = c.account 
	   LEFT JOIN location_types lt
			   ON lt.id = c.location_type
WHERE  a.id = @accountid  
		AND c.id = @id
END















GO
/****** Object:  StoredProcedure [dbo].[usp_GetParentAccount]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetParentAccount]
@userId int
AS
BEGIN

Select ID, Name from accounts
where role = (select id from users where id = @userId)

END






GO
/****** Object:  StoredProcedure [dbo].[usp_NewAccountLocation]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NewAccountLocation]
@account int,
@address nvarchar(100),
@address_line2 nvarchar(100),
@city nvarchar(50),
@state_abr nvarchar(10) = null,
@state nvarchar(50) = null,
@zip_code nvarchar(50),
@location_type nvarchar(100),
@role int
AS
BEGIN

DECLARE
@state_id int,
@location_type_int int,
@new_id int
IF @state_abr is null
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state] = @state ) 
END
ELSE
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state_abr] = @state_abr ) 
END

SET @location_type_int = (SELECT id from [dbo].[location_types] where [location_type] = @location_type)
IF @location_type_int is null

INSERT INTO location_types (location_type, role)
Values( @location_type, @role)
SET @location_type_int = (SELECT id from [dbo].[location_types] where [location_type] = @location_type)


INSERT INTO [dbo].[account_locations] (account, address, address_line2, city, state, zip_code, location_type)
VALUES (@account, @address, @address_line2, @city, @state_id, @zip_code, @location_type_int)
END

SELECT @new_id = SCOPE_IDENTITY()
SELECT @new_id AS id
return









GO
/****** Object:  StoredProcedure [dbo].[usp_NewContact]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NewContact]
@account int,
@name nvarchar(100),
@title nvarchar(10),
@address nvarchar(100),
@address_line2 nvarchar(100),
@city nvarchar(50),
@state_abr nvarchar(10) = null,
@state nvarchar(50) = null,
@zip_code nvarchar(50),
@country nvarchar(50),
@phone_number nvarchar(50),
@secondary_number nvarchar(50),
@email nvarchar(100)
AS
BEGIN

DECLARE
@state_id int

IF @state_abr is null
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state] = @state ) 
END
ELSE
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state_abr] = @state_abr ) 
END

INSERT INTO [dbo].[contacts] (account, name, title, address, address_line2, city, state, zip_code, country, phone_number, secondary_number, email)
VALUES (@account, @name, @title, @address, @address_line2, @city, @state_id, @zip_code, @country, @phone_number, @secondary_number, @email)
END









GO
/****** Object:  StoredProcedure [dbo].[usp_updateAddGeoCodes]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_updateAddGeoCodes]
	-- Add the parameters for the stored procedure here
 @location_id int,
 @lat nvarchar(100),
 @long nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM [dbo].[geo_cordinates] WHERE [location_id]=@location_id)
		UPDATE [dbo].[geo_cordinates] SET lat = @lat, long = @long WHERE location_id = @location_id
	ELSE
		INSERT INTO [dbo].[geo_cordinates] (location_id, lat, long) VALUES (@location_id,@lat,@long) 
END


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateContact]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateContact]
@id int,
@name nvarchar(100),
@title nvarchar(10),
@address nvarchar(100),
@address_line2 nvarchar(100),
@city nvarchar(50),
@state_abr nvarchar(10) = null,
@state nvarchar(50) = null,
@zip_code nvarchar(50),
@country nvarchar(50),
@phone_number nvarchar(50),
@secondary_number nvarchar(50),
@email nvarchar(100)
AS
BEGIN

DECLARE
@state_id int

IF @state_abr is null
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state] = @state ) 
END
ELSE
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state_abr] = @state_abr ) 
END

UPDATE [dbo].[contacts]
SET name = @name, title = @title, address = @address, address_line2 = @address_line2, city = @city, state = @state_id, zip_code = @zip_code, country = @country, phone_number = @phone_number, secondary_number = @secondary_number, email = @email
WHERE id = @id
END








GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLocation]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateLocation]
@id int,
@name nvarchar(100),
@address nvarchar(100),
@address_line2 nvarchar(100),
@city nvarchar(50),
@state_abr nvarchar(10) = null,
@state nvarchar(50) = null,
@zip_code nvarchar(50)
AS
BEGIN

DECLARE
@state_id int

IF @state_abr is null
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state] = @state ) 
END
ELSE
BEGIN
	set @state_id = (SELECT id from [dbo].[states] where [state_abr] = @state_abr ) 
END

UPDATE [dbo].[account_locations]
SET name = @name, address = @address, address_line2 = @address_line2, city = @city, state = @state_id, zip_code = @zip_code
WHERE id = @id
END










GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateSalesInformation]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usp_UpdateSalesInformation]
@id int,
@sales_stage nvarchar(50),
@account_rank varchar(5),
@volume float,
@units nvarchar(50),
@revenue decimal(19,4),
@visits_per_year int
AS
BEGIN

Update [dbo].[accounts]
Set sales_stage = (select id from [dbo].[sales_stages] where sales_stage = @sales_stage),
	units = (select id from [dbo].[units] where unit = @units),	
	account_rank = @account_rank,
	volume = @volume,
	revenue = @revenue,
	visits_per_year = @visits_per_year
Where id = @id

END


GO
/****** Object:  Table [dbo].[account_locations]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[address] [nvarchar](100) NULL,
	[address_line2] [nvarchar](100) NULL,
	[city] [nvarchar](50) NULL,
	[state] [int] NULL,
	[zip_code] [nvarchar](15) NULL,
	[location_type] [int] NULL,
	[account] [int] NULL,
 CONSTRAINT [PK_account_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[account_types]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[account_type] [nvarchar](100) NULL,
 CONSTRAINT [PK_account_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[accounts]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[name] [nvarchar](100) NOT NULL,
	[account_type] [int] NULL,
	[sales_stage] [int] NULL,
	[volume] [float] NULL,
	[units] [int] NULL,
	[revenue] [decimal](19, 4) NULL,
	[account_rank] [varchar](5) NULL,
	[visits_per_year] [int] NULL,
	[main_contact] [int] NULL,
	[parent] [int] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[contacts]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[title] [nvarchar](10) NULL,
	[address] [nvarchar](100) NULL,
	[address_line2] [nvarchar](100) NULL,
	[city] [nvarchar](50) NULL,
	[state] [int] NULL,
	[zip_code] [nvarchar](50) NULL,
	[country] [varchar](50) NULL,
	[phone_number] [nvarchar](50) NULL,
	[secondary_number] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK_contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[geo_cordinates]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[geo_cordinates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[location_id] [int] NOT NULL,
	[lat] [nvarchar](100) NULL,
	[long] [nvarchar](100) NULL,
 CONSTRAINT [PK_geo_cordinates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[location_types]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[location_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_location_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sales_stages]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_stages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[sales_stage] [nvarchar](50) NULL,
 CONSTRAINT [PK_sales_stages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[states]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[states](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[state] [nvarchar](50) NULL,
	[state_abr] [nvarchar](5) NULL,
 CONSTRAINT [PK_states] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[units]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[unit] [nvarchar](50) NULL,
 CONSTRAINT [PK_units] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 1/19/2013 4:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[admin] [bit] NULL,
	[remember_token] [bit] NOT NULL,
	[created] [datetime] NULL,
	[updated] [datetime] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[account_locations]  WITH CHECK ADD  CONSTRAINT [fk_account_locations_account] FOREIGN KEY([account])
REFERENCES [dbo].[accounts] ([id])
GO
ALTER TABLE [dbo].[account_locations] CHECK CONSTRAINT [fk_account_locations_account]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_account_types] FOREIGN KEY([account_type])
REFERENCES [dbo].[account_types] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_account_types]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [fk_accounts_main_contact] FOREIGN KEY([main_contact])
REFERENCES [dbo].[contacts] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [fk_accounts_main_contact]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [fk_accounts_sales_stage] FOREIGN KEY([sales_stage])
REFERENCES [dbo].[sales_stages] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [fk_accounts_sales_stage]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [fk_accounts_units] FOREIGN KEY([units])
REFERENCES [dbo].[units] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [fk_accounts_units]
GO
