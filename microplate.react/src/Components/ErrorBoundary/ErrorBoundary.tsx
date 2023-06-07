import { Component, ErrorInfo, ReactNode } from 'react';
import './ErrorBoundary.css';

interface ErrorBoundaryState {
    hasError: boolean;
    error: Error | null;
    errorInfo: ErrorInfo | null;
}

class ErrorBoundary extends Component<ReactNode, ErrorBoundaryState> {
    state: ErrorBoundaryState = {
        hasError: false,
        error: null,
        errorInfo: null,
    };

    componentDidCatch(error: Error, errorInfo: ErrorInfo) {
        // Log the error to an error logging service
        console.error(error, errorInfo);

        // Update state to display fallback UI
        this.setState({ hasError: true, error, errorInfo });
    }

    render() {
        if (this.state.hasError) {
            // Display fallback UI
            return (
                <div>
                    <h1>Something went wrong.</h1>
                    <p>{this.state.error && this.state.error.toString()}</p>
                    <pre>{this.state.errorInfo && this.state.errorInfo.componentStack}</pre>
                </div>
            );
        }

        // Render children if there are no errors
        return this.props.children;
    }
}

export default ErrorBoundary;