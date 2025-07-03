import { Form, Button } from 'react-bootstrap';

import './Contact.css';
import React, { useState } from 'react';


import { useNavigate } from 'react-router-dom';


import axios from 'axios';


const Contact = () => {
    const apiBase = "http://localhost:44366/";
    const [food, setFood] = useState({
        rname: '',
        imgdata: '',
        address: '',
        delimg: '',
        somedata: '',
        price: '',
        rating: '',
        arrimg: ''
    });

    const handleChange = event => {
        const { name, value } = event.target;
        setFood(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = event => {
        event.preventDefault();
        if(!food.rname || !food.imgdata || !food.address || !food.delimg || !food.somedata || 
            !food.price || !food.rating || !food.arrimg)
        {
            return;
        }
        axios.post(`${apiBase}/api/zmt`, food)
            .then(response => {
                console.log(response);
                setFood({
                    rname: '',
                    imgdata: '',
                    address: '',
                    delimg: '',
                    somedata: '',
                    price: '',
                    rating: '',
                    arrimg: ''
                });
                
            })
            .catch(error => console.log(error));
    };





    const navigate = useNavigate();
    const onClickOrderNow = () => {
        navigate("/Search");
    }
    return (
        <div class="contact">
            <h4 className='text-center'>
                Add Restaurant
            </h4>

            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="rname">
                    <Form.Label>Restaurant Name:</Form.Label>
                    <Form.Control type="text" name="rname" value={food.rname} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="imgdata">
                    <Form.Label>Image Data:</Form.Label>
                    <Form.Control type="text" name="imgdata" value={food.imgdata} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="address">
                    <Form.Label>Address:</Form.Label>
                    <Form.Control as="textarea" rows={3} name="address" value={food.address} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="delimg">
                    <Form.Label>Delivery Image:</Form.Label>
                    <Form.Control type="text" name="delimg" value={food.delimg} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="somedata">
                    <Form.Label>Some Data:</Form.Label>
                    <Form.Control type="text" name="somedata" value={food.somedata} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="price">
                    <Form.Label>Price:</Form.Label>
                    <Form.Control type="number" name="price" value={food.price} onChange={handleChange} />
                </Form.Group>
                <Form.Group controlId="rating">
                    <Form.Label>Rating:</Form.Label>
                    <Form.Control type="number" name="rating" value={food.rating} onChange={handleChange} max="5" maxLength={1} min="0" />
                </Form.Group>
                <Form.Group controlId="arrimg">
                    <Form.Label>Array of Images:</Form.Label>
                    <Form.Control type="text" name="arrimg" value={food.arrimg} onChange={handleChange} />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>
        </div>
    )
}

export default Contact
