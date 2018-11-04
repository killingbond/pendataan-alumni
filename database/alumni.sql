-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 09, 2017 at 02:56 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `alumni`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_alumni`
--

CREATE TABLE `data_alumni` (
  `nomor_induk` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `tahun_keluar` int(11) NOT NULL,
  `alamat` varchar(30) NOT NULL,
  `telepon` varchar(20) NOT NULL,
  `data_1` varchar(200) NOT NULL,
  `data_2` varchar(200) NOT NULL,
  `data_3` varchar(200) NOT NULL,
  `data_4` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `data_alumni`
--

INSERT INTO `data_alumni` (`nomor_induk`, `nama`, `tahun_keluar`, `alamat`, `telepon`, `data_1`, `data_2`, `data_3`, `data_4`) VALUES
(3, 'jaja', 2014, 'bandung', '543453', '', '', '', ''),
(4, 'wqwq', 2014, 'bandung', '4563435', '', '', '', ''),
(5, 'qwqw', 2014, 'bandung', '543', '', '', '', ''),
(6, 'asdasd', 2014, 'bandung', '453453', '', '', '', ''),
(10, 'adit', 2014, 'banng', '5415641', '', '', '', ''),
(10111094, 'Aditya Purnama R', 2009, 'Gading Tutuka 2', '085722439538', '20170501143436alur.JPG', '20170501143440water.jpg', '20170501143448ATmega8_diagram.jpg', '2017050114341810111094.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `id_pengguna` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `uname` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`id_pengguna`, `nama`, `uname`, `pass`) VALUES
(1, 'aditya', 'adit', 'bandung');

-- --------------------------------------------------------

--
-- Table structure for table `profile`
--

CREATE TABLE `profile` (
  `id_profile` int(11) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `logo` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `profile`
--

INSERT INTO `profile` (`id_profile`, `nama`, `logo`) VALUES
(1, 'SDN 1 MARGAHAYU', '20170504141246logo-tut-wuri-handayani-kuning-01.png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data_alumni`
--
ALTER TABLE `data_alumni`
  ADD PRIMARY KEY (`nomor_induk`),
  ADD UNIQUE KEY `nomor_induk` (`nomor_induk`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`id_pengguna`),
  ADD UNIQUE KEY `uname` (`uname`);

--
-- Indexes for table `profile`
--
ALTER TABLE `profile`
  ADD PRIMARY KEY (`id_profile`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
