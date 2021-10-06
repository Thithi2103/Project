
drop database if exists marketapps;
create database marketapps;
use marketapps;
CREATE TABLE IF NOT exists `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(80) NOT NULL,
  `phoneNumber` varchar(20) NOT NULL,
  `user_name` varchar(40) NOT NULL unique,
  `password` varchar(20) NOT NULL,
  PRIMARY KEY (`user_id`)
);


CREATE TABLE IF NOT exists `application` (
  `app_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(80) NOT NULL,
  `kind` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `description` varchar(255) NOT NULL,
  `publisher` varchar(80) NOT NULL,
  `datepublish` datetime DEFAULT CURRENT_TIMESTAMP,
  `size` double NOT NULL,
  `ratings` varchar (5) NOT NULL,
  PRIMARY KEY (`app_id`)
);

CREATE TABLE IF NOT exists `payment` (
  `payment_id` int(11) NOT NULL auto_increment,
  `user_id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `money` decimal(10,0) DEFAULT '0',
  PRIMARY KEY (`payment_id`,`user_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
);

CREATE TABLE IF NOT exists `bill` (
  `bill_id` int(11) NOT NULL AUTO_INCREMENT,
  `app_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `payment_id` int(11) NOT NULL,
  `unitprice` decimal(10,0) DEFAULT NULL,
  `datacreate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`bill_id`),
  KEY `app_id` (`app_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `bill_ibfk_1` FOREIGN KEY (`app_id`) REFERENCES `application` (`app_id`),
  CONSTRAINT `bill_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `bill_ibfk_3` FOREIGN KEY (`payment_id`) REFERENCES `payment` (`payment_id`)
);


CREATE TABLE IF NOT exists `appbougth` (
  `user_id` int(11) NOT NULL,
  `app_id` int(11) NOT NULL,
  PRIMARY KEY (`user_id`,`app_id`),
  KEY `app_id` (`app_id`),
  CONSTRAINT `appbougth_ibfk_1` FOREIGN KEY (`app_id`) REFERENCES `application` (`app_id`),
  CONSTRAINT `appbougth_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
);

-- trigger --
DELIMITER $$
CREATE TRIGGER `tg_checkAppbought` BEFORE INSERT ON `bill` FOR EACH ROW begin
	if exists (select app_id from appbougth where user_id = new.user_id and app_id = new.app_id) then
		signal sqlstate '11111' set message_text = 'Wrong! this app has bougth!';
	end if;
end $$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `tg_autoInsertAppbought` AFTER INSERT ON `bill` FOR EACH ROW begin
	insert into appbougth values(new.user_id, new.app_id);
end $$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `tg_autoDeleteAppbougth` AFTER DELETE ON `bill` FOR EACH ROW begin
	delete from appbougth where app_id = old.app_id and user_id = old.user_id;
end $$
DELIMITER ;



-- insert data ---
INSERT INTO `user` VALUES (1,'Hoàng Đình Thi','0964303957','hoangthi','123456'),(2,'Vũ Hải Đăng','012345689','haidang','123456');
INSERT INTO `application` VALUES (11,'Flapy Bird','Game',2000.00,'loop game','Nguyen Ha Dong','2018-07-18 21:39:52','5','★★★☆☆'),
(1,'Zalo','App',30000.00,'VoIP and Instant Messaging','Zalo Group, VNG','2018-07-20 20:54:51','8000','★★☆☆☆'),
(2,'TeamView','App',10000.00,'Remote Control, Webinar','TeamViewer GmbH, Germany','2018-07-20 20:54:51','3000','★★☆☆☆'),
(3,'Spotify','App',1000.00,'Music','Daniel Ek, Martin Lorentzon','2018-07-20 20:54:51','500','★★★☆☆'),
(4,'Telegram','App',1000.00,'Instant message','Telegram FZ LLC, Telegram Messenger Inc','2020-07-20 20:58:27','5000','★★★★★'),
(5,'Zoom','App','7000.00','Action, Casual, Indie, Massively Multiplayer, Sports','Eric Yuan','2020-11-1','3000','★★★☆☆'),
(6,'Krita','App','1200.00','Krita Project','Krita Project','2018-10-6','9000','★★☆☆☆'),
(7,'Discord','App','5000.00','VoIP, instant messaging, video chat, networking','Discord','2012-08-22','40000','★★★☆☆'),
(8,'Adobe Photoshop','App','6000.00','Raster/Vector Graphics','Adobe Systems','2017-08-28','50000','★★★☆☆'),
(9,'Facebook','App','2000.00','Social network','Mark Zuckerberg','2004-02-04','1000','★★★☆☆'),
(20,'Adobe Premiere Pro','App',20000.00,'Video editing software','Adobe Systems','2018-10-12',20000,'★★★☆☆'),
(12,'King of Crabs','Game',1000.00,'Action, Casual, Multiplayer','Robot Squid','2020-03-17','5','★★☆☆☆'),
(13,'Dota2','Game',1000.00,'Action, Strategy','War','2018-07-18 22:00:36','7000','★★★★☆'),
(14,'LOL','Game',1100.00,'game teamwork','Riot','2018-07-20 10:28:39','7000','★★★★★'),
(15,'AOE','Game ',25000.00,'Action','Microsoft','2018-07-20 10:28:39','100000','★★★☆☆'),
(16,'Call Of Duty','Game',200000.00,'Action, Adventure','Activision, Aspyr (Mac)','2018-07-20 10:35:19','200000','★★★★★'),
(17,'Paladins','Game',1100.00,'teamwork','HiRez Studios','2018-07-20 20:54:51','4000','★★★☆☆'),
(18,'CrossFire','Game',1100.00,'Multi-genre shooting','SmileGate','2018-07-20 20:54:51','6000','★★★★★'),
(19,'PUBG','Game',30000.00,'Action, Adventure, Multiplayer','PUBG Corporation','2018-07-20 20:54:51','9000','★★★★☆')

;
INSERT INTO `payment` VALUES (1,1,'By Store',1000000),(2,2,'Visa',0),(3,1,'VietinBank',0),(1,2,'By Store',1000000);
INSERT INTO `bill`(app_id, user_id, payment_id, unitprice) values (2, 1, 1, 10000.00);


-- create user 'thi'@'%' identified by '21032002';
-- create user 'thi'@'localhost' identified by '21032002';
-- create user 'thi'@'localhost' identified by '21032002';
select *from application;

