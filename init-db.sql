DROP TABLE
    IF EXISTS cliente
    CASCADE;
    
DROP TABLE
    IF EXISTS usuario
    CASCADE;
    
    
CREATE TABLE usuario (
    id serial
    ,nome VARCHAR(255)
    ,email VARCHAR(255)
    ,senha VARCHAR(255)
    ,tipo SMALLINT
    ,STATUS bool
    ,PRIMARY KEY (id)
    );

CREATE TABLE cliente (
	id serial
	,nome VARCHAR(255)
	,cpf VARCHAR(255)
	,email VARCHAR(255)
	,telefone VARCHAR(255)
	,aniversario TIMESTAMP
	,PRIMARY KEY (id)
	);
    
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(1, 'Artur', '12345678', 'email@teste.com', '79999999999', '2020-01-24 23:11:42.873');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(2, 'Yan', '22222222', 'yan@yahoo.com', '79999999999', '2003-02-02 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(3, 'Henrique', '66666666', 'henrique@bol.com', '11999999999', '2004-02-03 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(4, 'Jurandir', '77777777', 'jurandir@outlook.com', '81999999999', '2008-02-03 00:00:00.000');
INSERT INTO public.cliente
(id, nome, cpf, email, telefone, aniversario)
VALUES(5, 'Calabreso', '88888888', 'calabreso@aurora.com', '71999999999', '1999-02-03 00:00:00.000');

INSERT INTO public.usuario
(id, nome, email, senha, tipo, status)
VALUES(1, 'Claudinho', 'claudinho@music.com', '**********', 0, true);
INSERT INTO public.usuario
(id, nome, email, senha, tipo, status)
VALUES(2, 'Buchecha', 'buchecha@sound.com', '**********', 1, true);

alter sequence cliente_id_seq restart with 6;
alter sequence usuario_id_seq restart with 3;