SELECT * FROM Book 
where (select MAX(AvailableCopies) from Book) = AvailableCopies