import React, { useState } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Button, Input } from "../../Components/FormComponents/FormComponents";

import api from "../../Services/Service"

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  async function handleSubmit(e) {
    //parar o submit do formulario
    e.preventDefault();
    //validar plmns 3 caracteres
    if (titulo.trim().length < 3) {
        alert ("O titulo deve ter no minimo 3 carecteres ")
        return;
    }
    //chamar a api

    try {
        const retorno = await api.post("/TiposEvento", {titulo: titulo})
        console.log("CADASTRADO COM SUCESSO");
        console.log(retorno.data)
        setTitulo(""); //limpa a variavel
    } catch (error) {
        console.log("Deu ruim na api");
        console.log(error);

    }

    


  }
  function handleUpdate() {
    alert("Bora Atualizar");
  }
  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator alterText={"???"} imageRender={eventTypeImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                /* Cadastrar*/
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <span>{titulo}</span>

                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <p>Tela de Edicao</p>
              )}

              {/* Atualizar  */}
            </form>
          </div>
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
