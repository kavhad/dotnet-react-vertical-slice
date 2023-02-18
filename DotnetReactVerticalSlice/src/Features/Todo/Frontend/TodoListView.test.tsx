import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import TodoListView from './TodoListView';

test('renders todo list and todo item', () => {
  render(<TodoListView todoLists={[{id:1, name: "Test List", list: [{id: 1, name: "Run Test", isComplete: false}]}]}/>);
  expect(screen.getByText(/Test List/i)).toBeInTheDocument();
  expect(screen.getByText(/Run Test/i)).toBeInTheDocument();
});
