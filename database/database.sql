
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
INSERT INTO `application` VALUES (1,'Flapy Bird','Game',2000.00,'Loop game','Nguyen Ha Dong','2018-07-18 21:39:52','5','★★★☆☆'),
(2,'King of Crabs','Game',1000.00,'Action, Casual, Multiplayer','Robot Squid','2020-03-21','5','★★☆☆☆'),
(3,'Dota2','Game',1000.00,'Action, Strategy','War','2018-07-18 22:00:36','7000','★★★★☆'),
(4,'LOL','Game',1100.00,'game teamwork','Riot','2018-07-20 10:28:39','7000','★★★★★'),
(5,'AOE','Game ',25000.00,'Action','Microsoft','2018-07-20 10:28:39','100000','★★★☆☆'),
(6,'Call Of Duty','Game',200000.00,'Action, Adventure','Activision, Aspyr (Mac)','2018-07-20 10:35:19','200000','★★★★★'),
(7,'Paladins','Game',1100.00,'teamwork','HiRez Studios','2018-07-20 20:54:51','4000','★★★☆☆'),
(8,'CrossFire','Game',1100.00,'Multi-genre shooting','SmileGate','2018-07-20 20:54:51','6000','★★★★★'),
(9,'PUBG','Game',30000.00,'Action, Adventure, Multiplayer','PUBG Corporation','2018-07-20 20:54:51','9000','★★★★☆'),
(10,'MOTHERGUNSHIP','Game',20000.00,'Action, Adventure','Digital Grip','2018-07-20 20:54:51','7000','★★★☆☆'),
(11,'Gladius Relics of war','Game',30000.00,'Action, Adventure, Multiplayer','Slitherine Ltd','2018-07-20 20:54:51','8000','★★☆☆☆'),
(12,'Dig or Die ','Game',10000.00,'Action, Indie, Role Playing (RPG), Strategy','Game Gaddy','2018-07-20 20:54:51','3000','★★☆☆☆'),
(13,'Super Sky Arena','Game',1000.00,'Action, Indie, Early Access','Hammer Labs, Deck13','2018-07-20 20:54:51','500','★★★☆☆'),
(14,'PICO PARK','Game',1000.00,'Action, Casual, Indie','TECOPARK','2020-07-20 20:58:27','5000','★★★★★'),
(15,'Fall Guys','Game','70000.00','Action, Casual, Indie, Massively Multiplayer, Sports','Mediatonic','2020-08-23','3000','★★★☆☆'),
(16,'Bless Unleashed','Game','1200.00','Action, Massively Multiplayer, Role Playing (RPG)','NEOWIZ','2021-08-21','9000','★☆☆☆'),
(17,'Counter-Strike: Global Offensive','Game','5000.00','Action','Valve','2012-08-22','40000','★★★☆☆'),
(18,'ARK: Survival Evolved','Game','6000.00','Action, Adventure, Indie, Massively Multiplayer, Role Playing (RPG)',' Studio Wildcard','2017-08-28','50000','★★★☆☆'),
(19,'Facebook','App','2000.00','Social network','Mark Zuckerberg','2004-9-14','1000','★★★☆☆')
;
INSERT INTO `payment` VALUES (1,1,'By Store',1000000),(2,2,'Visa',0),(3,1,'VietinBank',0);
INSERT INTO `bill`(app_id, user_id, payment_id, unitprice) values (2, 1, 1, 10000.00);


-- create user 'thi'@'%' identified by '21032002';
-- create user 'thi'@'localhost' identified by '21032002';
-- create user 'thi'@'localhost' identified by '21032002';
select *from application;

