import React from 'react';
import './Sass/main.scss';
import Header from './Components/Header';
import Footer from './Components/Footer';
import Main from './Components/Pages/Main';

function DateConvert(){

  var meses = [
    "Enero", "Febrero", "Marzo",
    "Abril", "Mayo", "Junio", "Julio",
    "Agosto", "Septiembre", "Octubre",
    "Noviembre", "Diciembre"
  ]
  var date = new Date();
  var dia = date.getDate();
  var mes = date.getMonth();
  var yyy = date.getFullYear();
  var fecha_formateada = dia + ' de ' + meses[mes] + ' de ' + yyy;

  return fecha_formateada;

}

function App() {
  return (
    <div className="App">
      <Header name='Contoso University' date={DateConvert}/>
      <Main />
      <Footer />
    </div>
  );
}

export default App;
