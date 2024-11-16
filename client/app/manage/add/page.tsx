"use client"

import { useState } from 'react';

const AddItemPage = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [upc, setUPC] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    if (!name || !upc) {
      setError('Name and UPC are required.');
      return;
    }

    const apiUrl = process.env.NEXT_PUBLIC_API_URL;
    try {
      const response = await fetch(apiUrl + "/items", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, description, upc }),
      });

      console.log(apiUrl);

      if (response.ok) {
        window.location.href = '/manage';
      } else {
        setError('Failed to add item. Try again.');
      }
    } catch (error) {
      setError('An unexpected error occurred.');
    }
  };

  return (
    <div className="max-w-lg mx-auto mt-10 bg-white p-6 rounded-lg shadow-md">
      <h1 className="text-2xl font-bold mb-4">Add New Item</h1>
      {error && <p className="text-red-500 mb-4">{error}</p>}
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            className="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700">Description</label>
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            className="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700">UPC</label>
          <input
            type="text"
            value={upc}
            onChange={(e) => setUPC(e.target.value)}
            className="mt-1 block w-full p-2 border border-gray-300 rounded-md shadow-sm"
            required
          />
        </div>
        <button
          type="submit"
          className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600"
        >
          Add Item
        </button>
      </form>
    </div>
  );
};

export default AddItemPage;
