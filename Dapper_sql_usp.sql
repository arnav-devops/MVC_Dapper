USE [MVCdapperDb]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 09-05-2023 21:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Salary] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddOrEdit]    Script Date: 09-05-2023 21:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmployeeAddOrEdit]
@EmployeeId int,
@Name varchar (50),
@Age int,
@Salary int
AS
IF (@EmployeeId =0)
INSERT INTO
Employee (Name, Age, Salary)
VALUES (@Name, @Age, @Salary)
ELSE
UPDATE Employee
SET
 Name = @Name, 
 Age = @Age,
Salary = @Salary
WHERE @EmployeeId = @EmployeeId
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDeleteById]    Script Date: 09-05-2023 21:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmployeeDeleteById]
@EmployeeId int 
AS
Delete  from Employee
where EmployeeId = @EmployeeId
GO
/****** Object:  StoredProcedure [dbo].[EmployeeViewAll]    Script Date: 09-05-2023 21:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EmployeeViewAll]

AS

SELECT * FROM Employee
GO
/****** Object:  StoredProcedure [dbo].[EmployeeViewByID]    Script Date: 09-05-2023 21:40:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[EmployeeViewByID]
@EmployeeId  int
AS
Select * from
Employee
Where EmployeeId  = @EmployeeId 
GO
