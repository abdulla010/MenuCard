import { Route, Routes } from 'react-router-dom'
import Search from './Search';
import Contact from './contact';

const Router = () => {
    return (
        <Routes>
            <Route exact path='*' element={<Search />} ></Route>
            <Route exact path='Contact' element={<Contact />} ></Route>
            <Route path="/" element={<Search />} />
            
            <Route path="contact-us" element={<Search />} /> 
        </Routes>
    )
}

export default Router
