
-- ���ݴ�����������Ƹ�������  ������������һ����Ϣ
if exists(select * from t_Names where Name='sss')
 begin 
 delete from t_Names where Name='sss'
 end 
 insert into t_Names (Name, Age) values('sss','111')

 -- case...end ����Χ�� ��ʾ���� 
 select * ,
	case 
		when Age <= 10 then '�ȼ�1'
		when Age <= 50 then '�ȼ�2'
		when Age <= 100 then '�ȼ�3'
		when Age <= 1000  then '�ȼ�4'
		when Age <= 10000 then '�ȼ�5'
		when Age > 10000 then '�ȼ�6'
	end 
from t_Names

--�Ӳ�ѯ : ��һ����ѯ�����Ϊһ�������������SQL���ʹ�ã�����ʹ����ͨ�ı�һ����
--������������Ĳ�ѯ��䱻��Ϊ�Ӳ�ѯ�����п���ʹ�ñ�ĵط�����������ʹ���Ӳ�ѯ�����档

-- ���������䡢��С���䡢ƽ�����䡢������
select (select max(Age) from t_Names) as '�������',
		(select min(Age) from t_Names) as '��С����',
		(select avg(Age) from t_Names) as 'ƽ������',
		(select sum(Age) from t_Names) as '������'

-- �ҳ������������10�� ������������ĸ����l��������Ա ����������ʾ
select * from (select * from t_Names where Age > 10 ) as person
		 where person.Name > 'l' order by Name Asc

select * from t_Names

--ȫ�ֱ���:
--���һ��T-SQL����Ĵ����
select @@ERROR

--��ȡ������ͬʱ���ӵ������Ŀ
select @@MAX_CONNECTIONS

--�������һ�β���ı��
select @@IDENTITY