import React, {useState} from "react";
import {useParams} from "react-router-dom";

const AddCustomer = () => {
    const { id } = useParams()
    
    const [message, setMessage] = useState();
    
    const [formData, setFormData] = useState({
        calendarId: id,
        name: '',
        surname: '',
        serviceType: '',
        dateStart: '',
        dateEnd: '',
        price: 0.0,
        phoneNumber: '',
        color: '#3174AD'
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        
        formData.calendarId = id
        
        console.log(formData);
        let token = window.localStorage.getItem("jwt");

        fetch("api/booking", {
            method: "PUT",
            headers: {
                "Content-Type": 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(formData)
        })
            .then(res => {
                if (!res.ok) {
                    throw new Error('Failed to create booking');
                }
                return res.headers.get('Location');
            })
            .then(url => {
                if (url) {
                    console.log(url)
                    window.location.replace(window.location.origin + url);
                } else {
                    setMessage('Nie udało się stworzyć rezerwacji.');
                }
            })
            .catch(error => {
            });
    };

    return (
        <div className="max-w-md mx-auto p-4 bg-white shadow-md rounded-lg">
            <h2 className="text-xl font-semibold mb-4">Dodaj klienta</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label htmlFor="name" className="block text-sm font-medium text-gray-700">Imie</label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="surname" className="block text-sm font-medium text-gray-700">Nazwisko</label>
                    <input
                        type="text"
                        id="surname"
                        name="surname"
                        value={formData.surname}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="serviceType" className="block text-sm font-medium text-gray-700">Usługa</label>
                    <input
                        type="text"
                        id="serviceType"
                        name="serviceType"
                        value={formData.serviceType}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="dateStart" className="block text-sm font-medium text-gray-700">Data początkowa</label>
                    <input
                        type="datetime-local"
                        id="dateStart"
                        name="dateStart"
                        value={formData.dateStart}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="dateEnd" className="block text-sm font-medium text-gray-700">Data końcowa</label>
                    <input
                        type="datetime-local"
                        id="dateEnd"
                        name="dateEnd"
                        value={formData.dateEnd}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="phoneNumber" className="block text-sm font-medium text-gray-700">Numer telefonu</label>
                    <input
                        type="tel"
                        id="phoneNumber"
                        name="phoneNumber"
                        value={formData.phoneNumber}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="address" className="block text-sm font-medium text-gray-700">Adres</label>
                    <input
                        type="text"
                        id="address"
                        name="address"
                        value={formData.address}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <label htmlFor="address" className="block text-sm font-medium text-gray-700">Kolor etykiety</label>
                    <input
                        type="color"
                        id="color"
                        name="color"
                        value={formData.color}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>
                
                <div>
                    <label htmlFor="price" className="block text-sm font-medium text-gray-700">Cena</label>
                    <input
                        type="number"
                        id="price"
                        name="price"
                        value={formData.price}
                        onChange={handleChange}
                        required
                        className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
                    />
                </div>

                <div>
                    <button
                        type="submit"
                        className="w-full px-4 py-2 bg-indigo-600 text-white font-semibold rounded-md shadow-sm hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                    >
                        Dodaj
                    </button>
                </div>
                
                <div className="text-danger">{message}</div>
            </form>
        </div>
    );
};

export default AddCustomer;