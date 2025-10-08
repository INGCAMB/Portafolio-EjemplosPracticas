CREATE TABLE IF NOT EXISTS `alumnos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  `codigocurso` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT = 1;

INSERT INTO `alumnos` (`id`, `nombre`, `email`, `codigocurso`) VALUES
(1, 'ricardo', 'carprueba@gmail.com', 1);
