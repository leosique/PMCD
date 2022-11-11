CREATE TABLE "Entregador" (
  id int PRIMARY KEY identity,
  nome varchar(255) default NULL,
  documento varchar(255),
  dataNascimento varchar(255),
);





INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Reese Paul','81035398621','2023-04-28');
INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Yardley Evans','55488444535','2023-01-26');
INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Priscilla Mccormick','35815825695','2023-06-22');
INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Alden Guy','02338727153','2023-09-15');
INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Chester Lester','46037574343','2021-12-31');
INSERT INTO Entregador (nome,documento,dataNascimento) VALUES('Daquan Snyder','58618217896','2023-10-27');






CREATE TABLE "Transponder" (
  id int PRIMARY KEY identity,
  codigo varchar(255)
);





INSERT INTO Transponder (codigo) VALUES('FVB92SPB5EO');
INSERT INTO Transponder (codigo) VALUES('MTW41ULB7TQ');
INSERT INTO Transponder (codigo) VALUES('FNI18HNI8KL');
INSERT INTO Transponder (codigo) VALUES('OIC14VTV4YJ');
INSERT INTO Transponder (codigo) VALUES('WNC35HBB3NT');









CREATE TABLE "Transportadora" (
  id int PRIMARY KEY identity,
  nome varchar(255) default NULL,
  cnpj varchar(255),
  senha varchar(100)
);


INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Flavia Gallagher','26648046657131','123');
INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Jana Caldwell','78215534028676','123');
INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Vladimir Vincent','95446426302082','123');
INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Paki Molina','35386112807663','123');
INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Jillian Acevedo','35328781282256','123');
INSERT INTO Transportadora (nome,cnpj,senha) VALUES('Dalton Gallagher','35544209650608','123');


CREATE TABLE "ResponsavelBosch" (
  id int PRIMARY KEY identity,
  nome varchar(255) default NULL,
  documento varchar(255),
  edv varchar(255)
);


INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Flavia Gallagher','59723654189','71396633');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Jana Caldwell','87587083678','85656814');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Vladimir Vincent','41842427240','76139865');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Paki Molina','65282537044','23296714');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Jillian Acevedo','26204087646','86055243');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Dalton Gallagher','57455329564','37440134');
INSERT INTO ResponsavelBosch (nome,documento,edv) VALUES('Rhona Blanchard','28861783348','62746822');


CREATE TABLE "Entrega" (
  id int PRIMARY KEY identity,
  placaCarro varchar(255),
  codigoInterno int NULL,
  pesoEntrada int NULL,
  pesoSaida int NULL,
  dataEntrega datetime NULL,
  liberado bit NULL,
  idTransponder integer FOREIGN KEY REFERENCES Transponder(id) NULL,
  idTransportadora int FOREIGN KEY REFERENCES Transportadora(id) NULL,
  idResponsavelBosch int FOREIGN KEY REFERENCES ResponsavelBosch(id) NULL
    
);


INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('LGS6Q79',3,27,43,'2022-09-10',0,2,3,7);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('ILW2K48',1,34,46,'2022-09-10',0,2,2,3);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('YRE2I63',2,22,47,'2022-09-10',0,3,3,5);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('OOH1E15',3,31,48,'2022-09-10',0,5,5,2);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('KPN9R36',0,25,50,'2022-09-10',0,2,5,4);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('JXP2V22',2,35,50,'2022-09-10',0,2,5,5);
INSERT INTO Entrega (placaCarro,codigoInterno,pesoEntrada,pesoSaida,dataEntrega,liberado,idTransponder,idTransportadora,idResponsavelBosch) VALUES('VUM9C61',2,39,41,'2022-09-10',0,2,3,4);




CREATE TABLE "EntregaEntregador" (
  id int PRIMARY KEY identity,
  motorista bit NULL,
  idEntregador int FOREIGN KEY REFERENCES Entregador(id) NULL,
  idEntrega int FOREIGN KEY REFERENCES Entrega(id) NULL
);



INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(3,2,0);
INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(2,3,1);
INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(5,4,0);
INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(1,4,1);
INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(2,2,1);
INSERT INTO EntregaEntregador (idEntregador,idEntrega,motorista) VALUES(3,4,1);