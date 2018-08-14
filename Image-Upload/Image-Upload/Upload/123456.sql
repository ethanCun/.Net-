
-- 数据存在则根据名称更新年龄  不存在则增加一条信息
if exists(select * from t_Names where Name='sss')
 begin 
 delete from t_Names where Name='sss'
 end 
 insert into t_Names (Name, Age) values('sss','111')

 -- case...end （范围） 显示级别 
 select * ,
	case 
		when Age <= 10 then '等级1'
		when Age <= 50 then '等级2'
		when Age <= 100 then '等级3'
		when Age <= 1000  then '等级4'
		when Age <= 10000 then '等级5'
		when Age > 10000 then '等级6'
	end 
from t_Names

--子查询 : 将一个查询语句做为一个结果集供其他SQL语句使用，就像使用普通的表一样，
--被当作结果集的查询语句被称为子查询。所有可以使用表的地方几乎都可以使用子查询来代替。

-- 标记最大年龄、最小年龄、平均年龄、总年龄
select (select max(Age) from t_Names) as '最大年龄',
		(select min(Age) from t_Names) as '最小年龄',
		(select avg(Age) from t_Names) as '平均年龄',
		(select sum(Age) from t_Names) as '总年龄'

-- 找出所有年龄大于10的 并且名字首字母大于l的所有人员 按照升序显示
select * from (select * from t_Names where Age > 10 ) as person
		 where person.Name > 'l' order by Name Asc

select * from t_Names

--全局变量:
--最后一个T-SQL错误的错误号
select @@ERROR

--获取创建的同时连接的最大数目
select @@MAX_CONNECTIONS

--返回最近一次插入的编号
select @@IDENTITY