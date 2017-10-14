

DELIMITER //
CREATE PROCEDURE vaciartablas ()
BEGIN
	truncate table requerimientos;
    truncate table pmp;
    truncate table necesidadbruta;
    truncate table necesidadneta;
    UPDATE `informatica industrial db`.`stock` SET `Cantidad`='5' WHERE `idProducto`='10056456' and`idAlmacen`='1';
	UPDATE `informatica industrial db`.`stock` SET `Cantidad`='3' WHERE `idProducto`='10056473' and`idAlmacen`='1';
	UPDATE `informatica industrial db`.`stock` SET `Cantidad`='6' WHERE `idProducto`='10056505' and`idAlmacen`='1';
END
//

DELIMITER ;
DROP PROCEDURE IF EXISTS vaciartablas;

DELIMITER ;
call vaciartablas();