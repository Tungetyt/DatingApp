select * from person

select * from university

select * from UniversityAttendance

select * from person p inner join UniversityAttendance a on p.PersonId = a.UserId inner join University u on u.UniversityId = a.UniversityId
