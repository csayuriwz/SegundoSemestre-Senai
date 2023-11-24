import React, { useEffect, useState } from "react";
import {
  Button,
  Input,
  Select,
} from "../../Components/FormComponents/FormComponents";
import Title from "../../Components/Title/Title";
import "../../Pages/EventosPage/EventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import eventImageIllustrator from "../../assets/images/evento.svg";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import TableEv from "../EventosPage/TableEv/TableEv";
import api from "../../Services/Service";
import Spinner from "../../Components/Spinner/Spinner";
import Notification from "../../Components/Notification/Notification";

const EventosPage = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [Eventos, setEventos] = useState([]);
  const [tipoEventos, setTipoEventos] = useState([]);
  const [showSpinner, setShowSpinner] = useState(true);
  const [frmEdit, setFrmEdit] = useState(true);

  const [titulo, setTitulo] = useState("");
  const [data, setData] = useState("");
  const [select, setSelect] = useState("");
  const [descricao, setDescricao] = useState("");
  const [idEvento, setIdEvento] = useState(null);
  const [instituicao, setIdInstituicao] = useState("eb404169-6b81-438b-9f04-1b34a49bcdd5");
  const [idTipoEvento, setIdTipoEvento] = useState("a76f1bf2-0dfe-4c0b-9236-4b334115602d");

  useEffect(() => {
    async function getEvento() {
      setShowSpinner(true);
      try {
        const promise = await api.get("/Evento");
        setEventos(promise.data);
      } catch (error) {
        console.log("Deu ruim na api");
      }
      setShowSpinner(false);
    }

    async function getTipoEvento() {
      setShowSpinner(true);
      try {
        const promise = await api.get("/TiposEvento");
        setTipoEventos(promise.data);
      } catch (error) {
        console.log("Deu ruim na api");
      }
      setShowSpinner(false);
    }
    getEvento();
    getTipoEvento();
  }, []);

  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/Evento/${id}`);
      console.log("Deletado COM SUCESSO");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      const promiseGet = await api.get("/Evento");
      setEventos(promiseGet.data);
    } catch (error) {
      console.log("Deu ruim na api");
    }
  }

  async function handleSubmit(e) {
    //parar o submit do formulario
    e.preventDefault();
    //validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O nome do evento precisa possuir 3 caracteres ou mais!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de aviso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
    //chamar a api 
    try {
      const promise = await api.post("/Evento", {
        nomeEvento: titulo,
        dataEvento: data,
        descricao: descricao,
        idTipoEvento: idTipoEvento,
        idInstituicao: instituicao

      });
      console.log("CADASTRADO COM SUCESSO");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      console.log(promise.data);
      setTitulo(""); //limpa a variavel

      const promiseGet = await api.get("/Evento");
      setEventos(promiseGet.data);
    } catch (error) {
      console.log("oie");
    }
  }

  async function handleUpdate(e) {
    e.preventDefault();

    //propriedade:valor

    try {
      const retorno = await api.put("/Evento/" + idEvento, { nomeEvento: titulo,
        dataEvento: data,
        descricao: descricao,
        idTipoEvento: idTipoEvento,
        idInstituicao: instituicao});

      const retornoGet = await api.get("/Evento");
      setEventos(retornoGet.data);

      editActionAbort();
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Problemas na atualizacao. Verifique a conexao com a internet!`,
        imgIcon: "danger",
        imgAlt: "Imagem de ilustração de perigo.",
        showMessage: true,
      });
    }
  }

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    //fazer um getById para pegar os dados

    try {
      const retorno = await api.get("/Evento/" + idElemento);

      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Deu ruim na api!`,
        imgIcon: "warning",
        imgAlt: "Imagem de ilustração de perigo.",
        showMessage: true,
      });
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("");
    setIdEvento(null);
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      {/*cadastro de eventos*/}

      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Eventos"} />
            <ImageIllustrator
              alterText={""}
              imageRender={eventImageIllustrator}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  value={titulo}
                  placeholder={"titulo"}
                  manipulationFunction={(e) => {
                    setTitulo(e.target.value);
                  }}
                />

                <Input
                  type={"text"}
                  id={"descricao"}
                  name={"descricao"}
                  value={descricao}
                  placeholder={"Descrição"}
                  manipulationFunction={(e) => {
                    setDescricao(e.target.value);
                  }}
                />

                <Select
                  id={""}
                  name={""}
                  required
                  tipoEventos={tipoEventos}
                  value={Select}
                  manipulationFunction={(e) => {
                    setSelect(e.target.value);
                  }}

                />

                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  value={data}
                  manipulationFunction={(e) => {
                    setData(e.target.value);
                  }}
                />
                {!frmEdit ? (
                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                ) : (
                  <>
                    <div className="buttons-editbox">
                      <Button
                        textButton="Atualizar"
                        id="atualizar"
                        name="atualizar"
                        type="submit"
                        additionalClass="button-component--middle"
                      />
                      <Button
                        textButton="Cancelar"
                        id="cancelar"
                        name="cancelar"
                        type="button"
                        manipulationFunction={editActionAbort}
                        additionalClass="button-component--middle"
                      />
                    </div>
                  </>
                )}
              </>
            </form>
          </div>
        </Container>
      </section>

      {/*listagem de eventos*/}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />
          <TableEv
            dados={Eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
