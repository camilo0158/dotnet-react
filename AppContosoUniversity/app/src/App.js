import React from 'react';
import './Sass/main.scss';
import Header from './Components/Header';
import Footer from './Components/Footer';
import Main from './Components/Pages/Main';

function App() {
  return (
    <div className="App">
      <Header name='Contoso University'/>
      <Main />
      <Footer />
    </div>
  );
}

export default App;
