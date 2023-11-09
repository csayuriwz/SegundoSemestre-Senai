import React, { useEffect, useState } from "react";

const TestePage = () => {
  const [count, setCount] = useState(10);
  const [calculation, setCalculation] = useState(10);

  //roda somente quando o componente for carregado
  //e tambem quando o count for atualizado (funcao de dependencia [count])
  useEffect(() => {
    setCalculation(count * 2)

  }, [count]); 

  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
      <p>Calculation: {calculation}</p>
    </div>
  );
};

export default TestePage;
