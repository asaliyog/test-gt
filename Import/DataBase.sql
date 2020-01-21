
**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

select * from Users where id in (2,3,4);

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

select u.first_name, u.last_name, (select count(id) from listings ls where ls.user_id = u.id and ls.status=2 ) as basic ,  (select count(id) from listings ls where ls.user_id = u.id and ls.status=3 ) as premium from Users u inner join listings l on u.id = l.user_id where u.status = 2 group by u.id ;


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

select u.first_name, u.last_name, (select count(id) from listings ls where ls.user_id = u.id and ls.status=2 ) as basic ,  (select count(id) from listings ls where ls.user_id = u.id and ls.status=3 ) 
as premium from Users u inner join listings l on u.id = l.user_id where u.status = 2 group by u.id  having premium > 0;



4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

select u.first_name, u.last_name, c.currency, sum(c.price)  from Users u inner join listings l on u.id = l.user_id inner join clicks c on l.id = c.listing_id where u.status = 2 and  c.created 
between '2013-01-01' and '2013-12-31' group by c.currency , u.id ;

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

INSERT INTO clicks (listing_id, price, currency, created) VALUES (3,4.00,'USD', '2020-01-20');

SELECT LAST_INSERT_ID();

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

select  distinct (l.name) as listing_name from listings l inner join clicks c on l.id = c.listing_id where c.created NOT BETWEEN '2013-01-01' and '2013-12-31';


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

select year(c.created) as date_ , count(c.id) as total_listings_clicked, count(distinct(lis.user_id)) as total_vendors_affected from clicks  c inner join listings lis on c.listing_id = lis.id group by year(created);


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

select u.first_name, u.last_name , group_concat( l.name) as listing_names from users u inner join listings l on u.id = l.user_id where u.status=2 group by u.id;