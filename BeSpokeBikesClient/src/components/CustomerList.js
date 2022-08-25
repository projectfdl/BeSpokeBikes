import React, { Component } from 'react';

export class CustomerList extends Component {
    static displayName = CustomerList.name;

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderDataTable(data) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Address</th>
                        <th>Phone</th>
                        <th>Start Date</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item =>
                        <tr key={item.id}>
                            <td>{item.firstName}</td>
                            <td>{item.lastName}</td>
                            <td>{item.address}</td>
                            <td>{item.phone}</td>
                            <td>{item.startDate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CustomerList.renderDataTable(this.state.data);

        return (
            <div>
                <h1 id="tabelLabel">Customers</h1>
                {contents}
            </div>
        );
    }

    async populateData() {

        const response = await fetch('/api/customer');

        console.log(response);

        const data = await response.json();

        this.setState({ data: data, loading: false });
    }
}
