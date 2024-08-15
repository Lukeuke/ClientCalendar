import React, {useState} from "react";

const CreateCalendar = () => {
  
  const [formData, setFormData] = useState({
    name: ''
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

    let token = window.localStorage.getItem("jwt");
    
    fetch("api/calendar", {
      method: "PUT",
      headers: {
        "Content-Type": 'application/json',
        'Authorization': `Bearer ${token}`
      },
      body: JSON.stringify(formData)
    }).then(res => {
      if (res.status === 201) {
        return res.json();
      }
    }).then(data => {
      window.location.replace(`/calendar/${data.id}`);
    })
  };

  return (
      <div className="max-w-md mx-auto p-4 bg-white shadow-md rounded-lg">
        <h2 className="text-xl font-semibold mb-4">Stwórz nowy kalendarz</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label htmlFor="name" className="block text-sm font-medium text-gray-700">Nazwa</label>
            <input
                type="text"
                id="calendarName"
                name="name"
                onChange={handleChange}
                value={formData.name}
                required
                className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 sm:text-sm"
            />
          </div>

          <div>
            <button
                type="submit"
                className="w-full px-4 py-2 bg-indigo-600 text-white font-semibold rounded-md shadow-sm hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
            >
              Stwórz
            </button>
          </div>
        </form>
      </div>
  );
};

export default CreateCalendar;