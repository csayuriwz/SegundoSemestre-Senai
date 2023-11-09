import React, { useEffect, useState } from "react";
import "./HomePage.css";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import Container from "../../Components/Container/Container";
import ContactSection from "../../Components/ContactSection/ContactSection";
import NextEvent from "../../Components/NextEvent/NextEvent";
import Title from "../../Components/Title/Title";


const HomePage = () => {
  
  //fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([
    {
      id: 1,
      title: "Evento X",
      descricao: "Evento de Sql Server",
      data: "10/11/2023",
    },
    {
      id: 2,
      title: "Evento Y",
      descricao: "Evento de Java",
      data: "11/11/2023",
    },
  ]);


  return (
    <MainContent>
      <Banner />

      {/* PROXIMOS EVENTOS */}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Proximos eventos"} />

          <div className="events-box">
            {nextEvents.map((e) => {
              return (
                <NextEvent
                  title={e.title}
                  description={e.descricao}
                  eventDate={e.data}
                  idEvento={e.id}
                />
              );
            })}

            <NextEvent
              title={"Evento x"}
              description={"Evento legal"}
              eventDate={"14/11/2023"}
              idEvento={"cewubhf1y367qwedqh"}
            />

            <NextEvent
              title={"Evento x"}
              description={"Evento legal"}
              eventDate={"14/11/2023"}
              idEvento={"cewubhf1y367qwedqh"}
            />

            <NextEvent
              title={"Evento x"}
              description={"Evento legal"}
              eventDate={"14/11/2023"}
              idEvento={"cewubhf1y367qwedqh"}
            />
          </div>
        </Container>
      </section>

      <VisionSection />

      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
