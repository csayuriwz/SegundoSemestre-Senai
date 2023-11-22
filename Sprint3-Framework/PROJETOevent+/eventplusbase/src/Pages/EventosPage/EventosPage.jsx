import React, { useEffect, useState } from "react";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import Title from "../../Components/Title/Title";
import "../../Pages/EventosPage/EventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import eventImageIllustrator from "../../assets/images/evento.svg";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import TableEv from "../EventosPage/TableEv/TableEv";
import api from "../../Services/Service";
import Spinner from "../../Components/Spinner/Spinner";

const EventosPage = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [Eventos, setEventos] = useState([]);
  const [tipoEventos, setTipoEventos] = useState([]);
  const [showSpinner, setShowSpinner] = useState(true);

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

      const promiseGet = await api.get("/TiposEvento");
      setEventos(promiseGet.data);
    } catch (error) {
      console.log("Deu ruim na api");
    }
  }

  return (
    <MainContent>
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

            <form className="ftipo-evento">
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  //   manipulationFunction={"???"} // PENDENTE
                />

                <Input
                  type={"text"}
                  id={"descricao"}
                  name={"descricao"}
                  placeholder={"Descrição"}
                  //   manipulationFunction={"???"} // PENDENTE
                />

                <select name="tipo-evento-select">
                  {tipoEventos.map((evento) => {
                    return <option>{`${evento.titulo}`}</option>;
                  })}
                </select>

                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  //   placeholder={"dd/mm/aaaa"}
                  //   manipulationFunction={"???"} // PENDENTE
                />
              </>
              /
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
            fnUpdate={handleDelete}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
