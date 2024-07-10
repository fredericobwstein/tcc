
CREATE TABLE public.usuario (
    id uuid NOT NULL,
    nome character varying(100) NOT NULL,
    email character varying(100) NOT NULL,
    senha character varying(100) NOT NULL,
    datacadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


CREATE TABLE public.usuario_listadesejo (
    usuario_id uuid,
    mal_id integer NOT NULL,
    datacadastro timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    id uuid
);


ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_email_key UNIQUE (email);

ALTER TABLE ONLY public.usuario
    ADD CONSTRAINT usuario_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.usuario_listadesejo
    ADD CONSTRAINT usuario_listadesejo_usuario_id_fkey FOREIGN KEY (usuario_id) REFERENCES public.usuario(id);


