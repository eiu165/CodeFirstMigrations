USE [CodeFirst]
GO



IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog]') AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE [dbo].[InsertLog] 
GO  

IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[ArticleTags]')  AND type IN ( N'U' ) )  delete  from    [ArticleTags]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Categories]')  AND type IN ( N'U' ) )  delete   from     [Categories]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Tags]')  AND type IN ( N'U' ) )  delete  from     [Tags]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Articles]')  AND type IN ( N'U' ) )  delete  from     [Articles]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Tasks]')  AND type IN ( N'U' ) )  delete   from     [Tasks] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Users]')  AND type IN ( N'U' ) )  delete   from     [Users] 




GO  

print ' ' 
print 'finished dropping all tables'
print ' '