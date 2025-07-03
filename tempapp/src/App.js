import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Search from './components/Search';
import { BrowserRouter } from 'react-router-dom';
import Header from './components/header';
import Router from './components/router';

function App() {
  return (
    <>
    
    
      
    <BrowserRouter>
    <Header/>  
    <Router/>
    
      {/* <Search /> */}
    </BrowserRouter>
    </>  


  );
}

export default App;
