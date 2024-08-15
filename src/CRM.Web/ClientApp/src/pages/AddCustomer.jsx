import React, {useState} from "react";

const AddCustomer = () => {
    const [formData, setFormData] = useState({
        name: '',
        surname: '',
        serviceType: '',
        dateStart: '',
        dateEnd: '',
        price: ''
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
        
        console.log('Form Data:', formData);
        
        fetch("api/client", {
            method: "PUT",
            body: JSON.stringify(formData)
        }).then(res => res.json())
        
        return;
        
        setFormData({
            name: '',
            surname: '',
            serviceType: '',
            dateStart: '',
            dateEnd: '',
            price: ''
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
            </form>
        </div>
    );
};

export default AddCustomer;