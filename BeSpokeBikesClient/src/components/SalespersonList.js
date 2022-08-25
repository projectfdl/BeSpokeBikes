import React, { Component } from 'react';

export class SalespersonList extends Component {
    static displayName = SalespersonList.name;

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
                        <th>Termination Date</th>
                        <th>Manager</th>
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
                            <td>{item.terminationDate}</td>
                            <td>{item.manager ? item.manager.firstName + ' ' + item.manager.lastName : '-'}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SalespersonList.renderDataTable(this.state.data);

        return (
            <div>
                <h1 id="tabelLabel">Salespeople</h1>
                {contents}
            </div>
        );
    }

    async populateData() {

        const response = await fetch('/api/salesperson');

        console.log(response);

        const data = await response.json();

        this.setState({ data: data, loading: false });
    }
}
